using SmartBooking.Domain.Entities;
using SmartBooking.Domain.Enums;

namespace SmartBooking.Domain.Agregates
{
    public class User
    {
        public Guid Id { get; private set; }
        public string Email { get; private set; }
        public string? PasswordHash { get; private set; }
        public RoleEnum Role { get; private set; }
        public DateTime JoinTime { get; private set; }
        public ProviderEnum Provider { get; private set; }

        private List<RefreshToken> _refreshTokens = new();
        public IReadOnlyCollection<RefreshToken> RefreshTokens => _refreshTokens.AsReadOnly();

        //For EF Core
        public User() { }

        public User(string email, ProviderEnum provider, string? passwordHash)
        {
            if(provider == ProviderEnum.Local && string.IsNullOrEmpty(passwordHash))
                throw new ArgumentException("Password hash cannot be null or empty for local provider.");

            Email = email;
            PasswordHash = passwordHash;
            JoinTime = DateTime.Now;
            Role = RoleEnum.DefaultUser; 
        }

        public void UpdatePassword(string oldPasswordHash, string newPassword)
        {
            if(Provider != ProviderEnum.Local)
                throw new InvalidOperationException("Cannot update password for non-local providers.");
            if (oldPasswordHash != PasswordHash)
                throw new InvalidOperationException();

            PasswordHash = newPassword;
        }

        public void AddRefreshToken(RefreshToken refreshToken)
            => _refreshTokens.Add(refreshToken);
    }
}

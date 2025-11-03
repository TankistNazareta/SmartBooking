namespace SmartBooking.Domain.Entities
{
    public class RefreshToken
    {
        public Guid Id { get; private set; }
        public Guid UserId { get; private set; }
        public DateTime ExpiresAt { get; private set; }
        public string Token { get; private set; }
        public bool IsRevoked { get; private set; }

        //For EF Core
        private RefreshToken() { }

        public RefreshToken(Guid userId, DateTime expiresAt, string token)
        {
            if(expiresAt <= DateTime.Now)
                throw new ArgumentException("Expiration time must be in the future.", nameof(expiresAt));

            UserId = userId;
            ExpiresAt = expiresAt;
            Token = token;
            IsRevoked = false;
        }

        public void Revoke()
        {
            IsRevoked = true;
        }
    }
}

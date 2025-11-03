namespace SmartBooking.Domain.Entities
{
    public class Coupon
    {
        public Guid Id { get; private set; }
        public bool IsActive { get; private set; }
        public string Code { get; private set; }
        public DateTime ExpireAt { get; private set; }
        public Guid? RentId { get; private set; }

        //For EF Core
        private Coupon() { }

        public Coupon(string code, DateTime expireAt)
        {
            if (expireAt <= DateTime.Now)
                throw new ArgumentException("Expiration time must be in the future.", nameof(expireAt));
            IsActive = true;
            Code = code;
            ExpireAt = expireAt;
        }

        public void ActivateCoupon(Guid rentId) 
        {
            if (!IsActive && ExpireAt <= DateTime.Now)
                throw new InvalidOperationException("Coupon is already used.");
            IsActive = false;
            RentId = rentId;
        }
    }
}

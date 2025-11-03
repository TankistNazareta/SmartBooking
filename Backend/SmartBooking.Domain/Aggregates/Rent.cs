using SmartBooking.Domain.Enums;

namespace SmartBooking.Domain.Aggregates
{
    public class Rent
    {
        public Guid Id { get; private set; }
        public Guid UserId { get; private set; }
        public Guid AlwaysAvailableTimeId { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime RentAt { get; private set; }
        public StatusEnum Status { get; private set; }
        public double Price { get; private set; }

        //For EF Core
        private Rent() { }

        public Rent(Guid userId, Guid alwaysAvailableTimeId, DateTime rentAt, double price)
        {
            UserId = userId;
            AlwaysAvailableTimeId = alwaysAvailableTimeId;
            CreatedAt = DateTime.Now;
            RentAt = rentAt;
            Status = StatusEnum.Pending;
            Price = price;
        }

        public void UpdateStatusToFailed() 
            => Status = StatusEnum.Failed;

        public void UpdateStatusToCompleted()
            => Status = StatusEnum.Completed;
    }
}

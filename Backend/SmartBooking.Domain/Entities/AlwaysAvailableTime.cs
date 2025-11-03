using SmartBooking.Domain.Enums;

namespace SmartBooking.Domain.Entities
{
    public class AlwaysAvailableTime
    {
        public Guid Id { get; private set; }
        public Guid RentElementId { get; private set; }
        public AlwaysAvailableTimeEnum AlwaysAvailableTimeEnum { get; private set; }

        //For EF Core
        private AlwaysAvailableTime() { }

        public AlwaysAvailableTime(Guid rentElementId, AlwaysAvailableTimeEnum alwaysAvailableTimeEnum)
        {
            RentElementId = rentElementId;
            AlwaysAvailableTimeEnum = alwaysAvailableTimeEnum;
        }
    }
}

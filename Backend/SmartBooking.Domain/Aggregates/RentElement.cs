using SmartBooking.Domain.Entities;

namespace SmartBooking.Domain.Agregates
{
    public class RentElement
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public double Price { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public string Description { get; private set; }
        public string Location { get; private set; }
        public Guid CategoryId { get; private set; }
        public Guid AdminId { get; private set; }
        private List<AlwaysAvailableTime> _alwaysAvailableTimes = new();
        public IReadOnlyCollection<AlwaysAvailableTime> AlwaysAvailableTimes => _alwaysAvailableTimes.AsReadOnly();

        //For EF Core
        private RentElement() { }

        public RentElement(string name, double price, string description, string location, Guid categoryId,  Guid adminId, List<AlwaysAvailableTime> alwaysAvailableTimes)
        {
            Name = name;
            Price = price;
            Description = description;
            Location = location;
            CategoryId = categoryId;
            AdminId = adminId;
            CreatedAt = DateTime.Now;
            _alwaysAvailableTimes = alwaysAvailableTimes;
        }

        public void UpdateDetails(string name, double price, string description, string location, List<AlwaysAvailableTime> alwaysAvailableTimes)
        {
            Name = name;
            Price = price;
            Description = description;
            Location = location;
            _alwaysAvailableTimes = alwaysAvailableTimes;
        }
    }
}

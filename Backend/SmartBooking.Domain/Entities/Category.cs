namespace SmartBooking.Domain.Entities
{
    public class Category
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }

        //For EF Core
        private Category() { }

        public Category(string name)
        {
            Name = name;
        }
    }
}

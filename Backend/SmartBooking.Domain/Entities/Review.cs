namespace SmartBooking.Domain.Entities
{
    public class Review
    {
        public Guid Id { get; private set; }
        public Guid UserId { get; private set; }
        public Guid RentElementId { get; private set; }
        public int Rating { get; private set; }
        public string Comment { get; private set; }

        //For EF Core
        private Review() { }

        public Review(Guid userId, Guid rentElementId, int rating, string comment)
        {
            if (rating < 1 || rating > 5)
                throw new ArgumentOutOfRangeException(nameof(rating), "Rating must be between 1 and 5.");

            UserId = userId;
            RentElementId = rentElementId;
            Rating = rating;
            Comment = comment;
        }
    }
}

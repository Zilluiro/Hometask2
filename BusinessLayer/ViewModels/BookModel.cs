namespace BusinessLayer.ViewModels
{
    public class BookModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }

        // Average rating
        public decimal Rating { get; set; }

        // Count of reviews
        public decimal ReviewsNumber { get; set; }
    }
}

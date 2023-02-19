namespace BusinessLayer.ViewModels
{
    public class BookDetailsModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }

        public decimal Rating { get; set; }

        public ICollection<ReviewModel> ReviewsNumber { get; set; }
    }
}

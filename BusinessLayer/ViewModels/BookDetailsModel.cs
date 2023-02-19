namespace BusinessLayer.ViewModels
{
    public class BookDetailsModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Cover { get; set; }
        public string Content { get; set; }

        public decimal Rating { get; set; }

        public ICollection<ReviewModel> Reviews { get; set; }
    }
}

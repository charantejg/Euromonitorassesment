namespace OnlineBookSubscription.Catalog.Application.DTO
{
    public class BooksDto
    {
        public int Id { get; set; }
        public string Isbn { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public double Price { get; set; }
        public string Thumbnail { get; set; }
    }
}
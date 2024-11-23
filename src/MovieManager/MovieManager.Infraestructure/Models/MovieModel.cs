namespace MovieManager.Infrastructure.Models
{
    public class MovieModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Director { get; set; }
        public string Genre { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public decimal Rating { get; set; }
    }
}

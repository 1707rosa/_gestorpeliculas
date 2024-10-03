namespace MovieManager.Web.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Director{ get; set; }
        public string Category { get; set; }
        public DateTime ReleaseDate { get; set; }
        public bool Rating { get; set; }


    }
}

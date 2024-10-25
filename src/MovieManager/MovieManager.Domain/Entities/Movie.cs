using System.ComponentModel.DataAnnotations;

namespace MovieManager.Domain.Entities
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        public string? Title { get; set; }

        public string? Director { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ReleaseDate { get; set; }

        public string ? Genre { get; set; }

        [Range(0, 10)]
        public decimal? Rating { get; set; }
    }
}

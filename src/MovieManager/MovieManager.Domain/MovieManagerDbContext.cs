using Microsoft.EntityFrameworkCore;
using MovieManager.Domain.Entities;

namespace MovieManager.Domain
{
    public class MovieManagerDbContext : DbContext
    {
        public MovieManagerDbContext(DbContextOptions<MovieManagerDbContext> options) : base(options) {}

        public DbSet<Movie> Movies { get; set; }

    }
}
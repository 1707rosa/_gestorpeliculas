using Microsoft.EntityFrameworkCore;
using MovieManager.Web.Models;

namespace MovieManager.Web.Data
{
    public class MovieManagerDbContext : DbContext
    {
        public MovieManagerDbContext(DbContextOptions<MovieManagerDbContext> options) : base(options) {}

        public DbSet<Movie> Movies { get; set; }

    }
}
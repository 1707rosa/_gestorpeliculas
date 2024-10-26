using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MovieManager.Domain
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<MovieManagerDbContext>
    {
        public MovieManagerDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MovieManagerDbContext>();
            optionsBuilder.UseSqlServer("Server=ROSA\\SQL2022;Database=MovieManagerDb;User Id=sa;Password=1108;TrustServerCertificate=true;");

            return new MovieManagerDbContext(optionsBuilder.Options);
        }
    }
}
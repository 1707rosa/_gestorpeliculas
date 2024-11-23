using Microsoft.EntityFrameworkCore;
using MovieManager.Domain;
using MovieManager.Domain.Entities;
//using MovieManager.Infraestructure.Interfaces;
//using MovieManager.Infrastructure.Context;
using MovieManager.Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieManager.Infrastructure.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MovieManagerDbContext _context;

        public MovieRepository(MovieManagerDbContext context)
        {
            _context = context;
        }

        public async Task<List<Movie>> GetAllMoviesAsync()
        {
            return await _context.Movies.ToListAsync();
        }

        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            return await _context.Movies.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task AddMovieAsync(Movie movie)
        {
            await _context.Movies.AddAsync(movie);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMovieAsync(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie != null)
            {
                _context.Movies.Remove(movie);
                await _context.SaveChangesAsync();
            }
        }
    }
}

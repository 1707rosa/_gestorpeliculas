using MovieManager.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieManager.Infrastructure.Interfaces
{
    public interface IMovieRepository
    {
        Task<List<Movie>> GetAllMoviesAsync();
        Task<Movie> GetMovieByIdAsync(int id);
        Task AddMovieAsync(Movie movie);
        Task DeleteMovieAsync(int id);
    }
}

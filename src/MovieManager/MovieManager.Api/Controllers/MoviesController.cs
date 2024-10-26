using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieManager.Domain;
using MovieManager.Api.Requests;
using MovieManager.Api.Responses;
using MovieManager.Domain.Entities;


namespace MovieManager.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly MovieManagerDbContext _context;

        public MoviesController(MovieManagerDbContext context)
        {
            _context = context;
        }

        
        [HttpGet("GetMovies")]
        public async Task<ActionResult<List<Movie>>> GetMovies()
        {
            return await _context.Movies.ToListAsync();
        }

        
        [HttpPost("AddMovie")]
        public async Task<ActionResult<NewMovieResponse>> AddMovie(NewMovieRequest request)
        {
            var movieDb = new Movie();

            movieDb.Title = request.Title;
            movieDb.Director = request.Director;
            movieDb.ReleaseDate = request.ReleaseDate;
            movieDb.Genre = request.Genre;
            movieDb.Rating = request.Rating;
           

            _context.Movies.Add(movieDb);
            await _context.SaveChangesAsync();

            return new NewMovieResponse { Id = movieDb.Id };
        }
    }
}

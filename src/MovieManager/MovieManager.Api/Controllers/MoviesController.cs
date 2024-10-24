using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieManager.Web.Data;
using MovieManager.Web.Requests;
using MovieManager.Web.Responses;
using MovieManager.Web.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

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
            var movieDb = new Movie
            {
                Title = request.Title,
                Director = request.Director,
                ReleaseDate = request.ReleaseDate,
                Genre = request.Genre,
                Rating = request.Rating
            };

            _context.Movies.Add(movieDb);
            await _context.SaveChangesAsync();

            return new NewMovieResponse { Id = movieDb.Id };
        }
    }
}

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

        [HttpPut("{id}")]
        public async Task<ActionResult<UpdateMovieResponse>> UpdateMovie(int id, [FromBody] UpdateMovieRequest request)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            movie.Title = request.Title;
            movie.Director = request.Director;
            movie.ReleaseDate = request.ReleaseDate;
            movie.Genre = request.Genre;
            movie.Rating = request.Rating;

            await _context.SaveChangesAsync();

            return new UpdateMovieResponse
            {
                Id = movie.Id,
                Message = "Movie updated successfully"
            };
        }

        [HttpDelete("DeleteMovie/{id}")]
        public async Task<ActionResult> DeleteMovie(int id)
        {
            var movieDb = await _context.Movies.FindAsync(id);
            if (movieDb == null)
            {
                return NotFound();
            }

            _context.Movies.Remove(movieDb);
            await _context.SaveChangesAsync();

            return NoContent();
        }


    }
}

using MovieManager.Domain.Entities;

namespace MovieManager.Web.Services
{
    public class MovieService
    {
        private readonly HttpClient _httpClient;

        public MovieService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("http://localhost:5094/api/"); 
        }

        public async Task<List<Movie>> GetMoviesAsync()
        {
            var response = await _httpClient.GetAsync("movies");
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<List<Movie>>();
        }

        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"movies/{id}");
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<Movie>();
        }
    }

}

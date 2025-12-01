using API.W.Movies.DAL.Models;
using API.W.Movies.DAL.Models.Dtos;

namespace API.W.Movies.Services.IServices
{
    public interface IMovieService
    {
        Task<ICollection<MovieDto>> GetMoviesAsync();
        Task<MovieDto> GetMovieAsync(int id);

        Task<Movie> AddMovieAsync(Movie movie);

        Task<bool> CreateMovieAsync(MovieCreateDto movieCreateDto);

        Task<bool> UpdateMovieAsync(Movie movie);

        Task<bool> DeleteMovieAsync(int id);
    }
}

using API.W.Movies.DAL.Models;
using API.W.Movies.DAL.Models.Dtos;

namespace API.W.Movies.Services.IServices
{
    public interface IMovieService
    {
        Task<ICollection<MovieDto>> GetMoviesAsync();
        Task<MovieDto> GetMovieAsync(int id);

        Task<Movie> AddMovieAsync(Movie movie);

        Task<MovieDto> CreateMovieAsync(MovieCreateDto movieCreateDto);

        Task<bool> UpdateMovieAsync(MovieCreateDto dto, int id);

        Task<bool> DeleteMovieAsync(int id);
    }
}

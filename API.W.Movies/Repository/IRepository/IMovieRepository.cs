using API.W.Movies.DAL.Models;
using API.W.Movies.DAL.Models.Dtos;

namespace API.W.Movies.Repository.IRepository
{
    public interface IMovieRepository
    {
        Task<ICollection<Movie>>GetMoviesAsync();
        Task<Movie> GetMovieAsync(int id);

        Task<Movie> AddMovieAsync(Movie movie);
        Task<bool> MovieExitsByNameAsync(string title);

        Task<MovieDto> CreateMovieAsync(Movie movie);

        Task<MovieDto> UpdateMovieAsync(MovieCreateDto dto,int id); 

        Task<bool> DeleteMovieAsync(int id);
    }
}

using API.W.Movies.DAL.Models;

namespace API.W.Movies.Repository.IRepository
{
    public interface IMovieRepository
    {
        Task<ICollection<Movie>>GetMoviesAsync();
        Task<Movie> GetMovieAsync(int id);

        Task<Movie> AddMovieAsync(Movie movie);
        Task<bool> MovieExitsByNameAsync(string title);

        Task<bool> CreateMovieAsync(Movie movie);

        Task<bool> UpdateMovieAsync(Movie movie); 

        Task<bool> DeleteMovieAsync(int id);
    }
}

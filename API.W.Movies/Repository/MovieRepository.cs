using API.W.Movies.DAL;
using API.W.Movies.DAL.Models;
using API.W.Movies.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace API.W.Movies.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly ApplicationDbContext _context;
        public MovieRepository(ApplicationDbContext context) 
        { 
            _context = context; 
        }    
        public async Task<Movie> AddMovieAsync(Movie movie)
        {
            movie.CreatedDate = DateTime.UtcNow;
            var addedMovie = await _context.Movies.AddAsync(movie);
            await _context.SaveChangesAsync();
            return movie;
        }
        public async Task<bool> MovieExistsByNameAsync(string name)
        {
            return await _context.Movies
                .AsNoTracking()
                .AnyAsync(c => c.Title == name);
        }

        public async Task<bool> CreateMovieAsync(Movie movie)
        {
            movie.CreatedDate = DateTime.UtcNow;
            var addedMovie = await _context.Movies.AddAsync(movie);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteMovieAsync(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            _context.Movies.Remove(movie);  
            return movie != null;   
        }

        public async Task<Movie> GetMovieAsync(int id)
        {
            var movie = _context.Movies
                .AsNoTracking()
                .FirstOrDefault(m => m.Id == id);
            return await Task.FromResult(movie);

        }

        public async Task<ICollection<Movie>> GetMoviesAsync()
        {
            var movie = _context.Movies
                .AsNoTracking()
                .OrderBy(m => m.Title)
                .ToListAsync();
            return await movie;
        }

        public async Task<bool> UpdateMovieAsync(Movie movie)
        {
            movie.ModifiedDate = DateTime.UtcNow;
            _context.Movies.Update(movie);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

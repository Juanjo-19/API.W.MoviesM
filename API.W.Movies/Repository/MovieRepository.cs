using API.W.Movies.DAL;
using API.W.Movies.DAL.Models;
using API.W.Movies.DAL.Models.Dtos;
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



        public async Task<bool> MovieExitsByNameAsync(string title)
        {
            return await _context.Movies
                .AsNoTracking()
                .AnyAsync(c => c.Title == title);
        }

        public async Task<MovieDto> CreateMovieAsync(Movie movie)
        {
            movie.CreatedDate = DateTime.UtcNow;
            var addedMovie = await _context.Movies.AddAsync(movie);
            await _context.SaveChangesAsync();
            return new MovieDto
            {
                Title = addedMovie.Entity.Title,
                Description = addedMovie.Entity.Description,
                Duration = addedMovie.Entity.Duration,
                Clasification = addedMovie.Entity.Clasification,
                ReleaseDate = new DateTime(addedMovie.Entity.ReleaseYear, 1, 1),
                CategoryId = addedMovie.Entity.CategoryId
            };
        }

        public async Task<MovieDto> UpdateMovieAsync(MovieCreateDto dto, int id)
        {
            var movie = await _context.Movies.FindAsync(id);

            if (movie == null)
            {
                return null; // o throw, depende del estilo de tu proyecto
            }

            // Actualizar campos
            movie.Title = dto.Title;
            movie.Description = dto.Description;
            movie.Duration = dto.Duration;
            movie.Clasification = dto.Clasification;
            movie.ReleaseYear = dto.ReleaseYear;
            movie.CategoryId = dto.CategoryId;
            movie.ModifiedDate = DateTime.UtcNow;

            // Guardar cambios
            _context.Movies.Update(movie);
            await _context.SaveChangesAsync();

            // Retornar DTO actualizado
            return new MovieDto
            {
                Id = movie.Id,
                Title = movie.Title,
                Description = movie.Description,
                Duration = movie.Duration,
                Clasification = movie.Clasification,
                ReleaseDate = new DateTime(movie.ReleaseYear, 1, 1),
                CategoryId = movie.CategoryId
            };

        }
    }
}

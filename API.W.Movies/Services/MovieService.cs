using API.W.Movies.DAL.Models;
using API.W.Movies.DAL.Models.Dtos;
using API.W.Movies.Repository.IRepository;
using API.W.Movies.Services.IServices;
using AutoMapper;

namespace API.W.Movies.Services
{
    public class MovieService: IMovieService
    {
        private readonly IMovieRepository _movieRepository;    
        private readonly IMapper _mapper;
        public MovieService(IMovieRepository movieRepository, IMapper mapper)

        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        public Task<Movie> AddMovieAsync(Movie movie)
        {
            throw new NotImplementedException();
        }
        public async Task<bool>MovieExitsByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<MovieDto> CreateMovieAsync(MovieCreateDto movieCreateDto)
        {
            var movieExits = await _movieRepository.MovieExitsByNameAsync(movieCreateDto.Title);
            if (movieExits)
            {
                throw new InvalidOperationException("Ya existe una pelicula con el mismo nombre");
            }
            var movie = _mapper.Map<Movie>(movieCreateDto);

            var movieCreated = await _movieRepository.CreateMovieAsync(movie);
            if (movieCreated == null)
            {
                throw new Exception("fallo en la creacion de pelicula");
            }

            return _mapper.Map<MovieDto>(movieCreated);

        }

        public async Task<bool> DeleteMovieAsync(int id)
        {
            var movieExists = await _movieRepository.GetMovieAsync(id);
            if (movieExists == null)
            {
                throw new InvalidOperationException("No se encontro la pelicula con ID: '{id}'");
            }
            var movieDeleted = await _movieRepository.DeleteMovieAsync(id);
            if (!movieDeleted)
            {
                throw new Exception("Fallo al eliminar la pelicula");
            }
            return movieDeleted;
        }

        public async Task<MovieDto> GetMovieAsync(int id)
        {
            var movie = _movieRepository.GetMovieAsync(id);
            return _mapper.Map<MovieDto>(movie);
        }

        public async Task<ICollection<MovieDto>> GetMoviesAsync()
        {
            var movies = await _movieRepository.GetMoviesAsync();
            return _mapper.Map<ICollection<MovieDto>>(movies);
            
        }

        public async Task<bool> UpdateMovieAsync(MovieCreateDto dto, int id)
        {
            var movieExists = await _movieRepository.GetMovieAsync(id);
            if (movieExists == null)
            {
                throw new InvalidOperationException("No se encontro la pelicula con ID: '{id}'");
            }
            var nameExists = await _movieRepository.MovieExitsByNameAsync(dto.Title);
            if (nameExists)
            {
                throw new InvalidOperationException("Ya existe una pelicula con el mismo nombre");
            }
            _mapper.Map(dto, movieExists);
            var movieUpdated = await _movieRepository.UpdateMovieAsync(dto,id);
            if (movieUpdated == null)
            {
                throw new Exception("Fallo al actualizar la pelicula");
            }
            return _mapper.Map<MovieDto>(movieUpdated) != null;
        }
    }
}

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

        public Task<bool> CreateMovieAsync(Movie movie)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteMovieAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<MovieDto> GetMovieAsync(int id)
        {
            var movie = _movieRepository.GetMovieAsync(id);
            return _mapper.Map<Task<MovieDto>>(movie);
        }

        public async Task<ICollection<MovieDto>> GetMoviesAsync()
        {
            var movies = await _movieRepository.GetMoviesAsync();
            return _mapper.Map<ICollection<MovieDto>>(movies);
            
        }

        public Task<bool> UpdateMovieAsync(Movie movie)
        {
            throw new NotImplementedException();
        }
    }
}

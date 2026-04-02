using WebApplication3.Models;
using WebApplication3.Repositories;

namespace WebApplication3.Services
{
    public class MovieService :IMovieService
    {
        private readonly IMovieRepository _repository;
        public MovieService(IMovieRepository repository)
        {
            _repository = repository;
        }

        public void CreateMovie(Movie movie)
        {
            _repository.Add(movie);
        }

        public void DeleteMovie(int id)
        {
            _repository.Delete(id);
        }

        public Movie GetMovie(int id)
        {
            return _repository.GetById(id);
        }

        public IEnumerable<Movie> GetMovies()
        {
            return _repository.GetAll();
        }

        public void UpdateMovie(Movie movie)
        {
            _repository.Update(movie);
        }
    }
}

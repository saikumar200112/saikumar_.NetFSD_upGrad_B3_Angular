using WebApplication3.Models;

namespace WebApplication3.Services
{
    public interface IMovieService
    {
        IEnumerable<Movie> GetMovies();
        Movie GetMovie(int id);
        void CreateMovie(Movie movie);
        void UpdateMovie(Movie movie);
        void DeleteMovie(int id);
    }
}

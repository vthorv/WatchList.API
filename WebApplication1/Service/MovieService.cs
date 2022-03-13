using Microsoft.AspNetCore.Mvc;
using WatchList.Model;

namespace WatchList.Service
{
    public interface IMovieService
    {
        IEnumerable<Movie> GetMovies();
        Movie? GetMovieById(int id);
        void CreateNewMovie(Movie movie);
        void UpdateMovie(Movie movie);
        void DeleteMovie(int id);
    }
    public class MovieService : IMovieService
    {
        private readonly List<Movie> movies = new List<Movie>
        {
            new Movie {
                Id = 1,
                Title = "Spider-Man: No Way Home",
                Watched = false,
                Summary = "With Spider-Man's identity now revealed, Peter asks Doctor Strange for help. When a spell goes wrong, dangerous foes from other worlds start to appear, forcing Peter to discover what it truly means to be Spider-Man.",
            },
            new Movie {
                Id = 2,
                Title = "The Batman",
                Watched = false,
                Summary = "When the Riddler, a sadistic serial killer, begins murdering key political figures in Gotham, Batman is forced to investigate the city's hidden corruption and question his family's involvement.",
            },
            new Movie {
                Id = 3,
                Title = "Don't Look Up",
                Watched = false,
                Summary = "Two low-level astronomers must go on a giant media tour to warn mankind of an approaching comet that will destroy planet Earth.",
            }
        };

        public IEnumerable<Movie> GetMovies()
        {
            return movies;
        }

        public Movie GetMovieById(int id)
        {
            return movies.SingleOrDefault(x => x.Id == id);
        }

        public void CreateNewMovie(Movie movie)
        {
            movies.Add(movie);
        }

        public void UpdateMovie(Movie movie)
        {
            var index = movies.FindIndex(x => x.Id == movie.Id);
            movies[index] = movie;
        }

        public void DeleteMovie(int id)
        {
            var index = movies.FindIndex(x => x.Id == id);
            movies.RemoveAt(index);
        }

    }
}

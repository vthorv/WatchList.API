using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WatchList.Model;
using WatchList.Service;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;  

        public MovieController(IMovieService movieService)
        {
            this._movieService = movieService;
        }

        [HttpGet(Name = "GetMovies")]
        public IEnumerable<Movie> GetMovies()
        {
            var movies = _movieService.GetMovies();
            return movies;
        }

        [HttpGet("{id}")]
        public ActionResult<Movie> GetMovie(int id)
        {
            var movie = _movieService.GetMovieById(id);
            if (movie is null)
            {
                return NotFound();
            }
            return movie;
        }

        [HttpPost]
        public ActionResult<Movie> CreateMovie(CreateMovieDto movieDto)
        {
            int nextID = -1;
            var movieIDs = _movieService.GetMovies().Select(x => x.Id).ToList();
            foreach (int id in movieIDs)
            {
                nextID = Math.Max(nextID, id);
            }

            Movie movie = new()
            {
                Id = nextID == -1 ? 1 : nextID + 1,
                Title = movieDto.Title,
                Watched = movieDto.Watched,
                Summary = movieDto.Summary
            };
            _movieService.CreateNewMovie(movie);
            return CreatedAtAction(nameof(GetMovie), new { id = movie.Id }, movie) ;
        }

        [HttpPut("{id}")]
        public ActionResult UpdateItem (int id, CreateMovieDto movieDto)
        {
            var existingMovie = _movieService.GetMovieById(id);
            if (existingMovie is null)
            {
                return NotFound();
            }
            Movie updatedMovie = new()
            {
                Id = existingMovie.Id,
                Title = movieDto.Title,
                Summary = movieDto.Summary,
                Watched = movieDto.Watched
            };
            _movieService.UpdateMovie(updatedMovie);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteItem (int id)
        {
            _movieService.DeleteMovie(id);
            return NoContent();
        }

    }
}
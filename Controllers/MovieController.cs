using DOE.EFWithStoredProcedure.Model;
using DOE.EFWithStoredProcedure.Services;
using Microsoft.AspNetCore.Mvc;

namespace DOE.EFWithStoredProcedure.Controllers
{
    [ApiController]
    [Route("Movies")]
    public class MovieController : ControllerBase
    {
        private readonly IMoviesServices _movieServices;

        public MovieController(IMoviesServices movieServices)
        {
            _movieServices = movieServices;
        }

        [HttpPost("Movie")]
        public ActionResult CreateMovie(CreateMoviedRequestDTO request)
        {
            var datacount = _movieServices.addMovie(request);
            if (datacount > 0)
            {
                return Ok(new
                {
                    NumberofrowsAffected = datacount,
                    status = "Created !"
                });
            }
            else
            {
                return NoContent();

            }
        }

        [HttpGet("All")]
        public List<Movie> GetMovies()
        {
            return _movieServices.movies();
        }

        [HttpGet("{genre}")]
        public List<Movie> Getmoviesbygnre(string genre)
        {
            return _movieServices.MoviesByGenre(genre);
        }

        [HttpGet("{genre}/{year}")]
        public List<Movie> GetmoviebyYearandGenre(string genre, string year)
        {
            return _movieServices.GetMovieByYearandGenre(genre, year);
        }

        [HttpGet("RateMovie/{ID}/{Ratting}")]
        public int MovieRate(string ID, string Ratting)
        {
            float rate = float.Parse(Ratting);
            return _movieServices.RateMovie(ID, rate);
        }
    }
}

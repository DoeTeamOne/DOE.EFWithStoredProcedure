using DOE.EFWithStoredProcedure.Context;
using DOE.EFWithStoredProcedure.Model;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DOE.EFWithStoredProcedure.Services
{
    public class MoviesServices : IMoviesServices
    {
        private readonly MovieContext _context;

        public MoviesServices(MovieContext context)
        {
            _context = context;
        }
        public int addMovie(CreateMoviedRequestDTO request)
        {
            SqlParameter title = new SqlParameter("@title", request.Title);
            SqlParameter year = new SqlParameter("@_year", request.Year);
            SqlParameter genre = new SqlParameter("@genre", request.Genre);

            return _context.Database.ExecuteSqlInterpolated($" Create_Movie {title},{year},{genre}");

        }

        public List<Movie> GetMovieByYearandGenre(string genre, string year)
        {
            return _context.Movies.FromSqlRaw($"GetMoviesByYearandGenre {genre},{year}").ToList();
        }

        public List<Movie> movies()
        {

            return _context.Movies.FromSqlRaw("AllMovies").ToList();
        }

        public List<Movie> MoviesByGenre(string genre)
        {
            return _context.Movies.FromSqlRaw($"GetMoviesByGenre {genre}").ToList();
        }

        public int RateMovie(string ID, float ratting)
        {
            return _context.Database.ExecuteSqlRaw($"RateMovie '{ID}',{ratting}");
        }
    }
}

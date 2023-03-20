using DOE.EFWithStoredProcedure.Model;

namespace DOE.EFWithStoredProcedure.Services
{
    public interface IMoviesServices
    {
        public int addMovie(CreateMoviedRequestDTO request);
        public List<Movie> movies();
        public List<Movie> MoviesByGenre(string genre);
        public List<Movie> GetMovieByYearandGenre(string genre, string year);
        public int RateMovie(string ID, float ratting);



    }
}

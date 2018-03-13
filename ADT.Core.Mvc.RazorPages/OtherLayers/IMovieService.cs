using System.Collections.Generic;

namespace ADT.Core.Mvc.RazorPages.OtherLayers
{
    public interface IMovieService
    {
        List<Movie> GetMovies();

        Movie GetMovie(int id);

        void AddMovie(Movie item);

        void UpdateMovie(Movie item);

        void DeleteMovie(int id);

        bool ExistsMovie(int id);
    }
}

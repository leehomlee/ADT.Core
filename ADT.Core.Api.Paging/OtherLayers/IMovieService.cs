using ADT.Core.Api.Paging.Lib;

namespace ADT.Core.Api.Paging.OtherLayers
{
    public interface IMovieService
    {
        PagedList<Movie> GetMovies(PagingParams pagingParams);
    }
}

using WebApi_Param_Odev.DBOperations;
using WebApi_Param_Odev.Entities;

namespace TestSetup
{
    public static class Genres
    {
        public static void AddGenres(this BookStoreDBContext context)
        {
            context.Genres.AddRange
            (
                new Genre{Name="Personal Growth"},
                new Genre{Name="Science Fiction"},
                new Genre{Name="Romance"}
            );
        }
    }
}
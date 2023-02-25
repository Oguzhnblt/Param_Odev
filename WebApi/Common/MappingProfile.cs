using AutoMapper;
using WebApi.Application.BookOperation.Command.CreatBook;
using WebApi_Param_Odev.Application.AuthorOperation.Queries.GetAuthors;
using WebApi_Param_Odev.Application.AuthorOperations.Commands.CreateAuthor;
using WebApi_Param_Odev.Application.AuthorOperations.Queries.GetAuthorDetail;
using WebApi_Param_Odev.Application.BookOperation.Queries.GetBookDetail;
using WebApi_Param_Odev.Application.BookOperation.Queries.GetBooks;
using WebApi_Param_Odev.Application.GenreOperations.Queries.GetGenreDetail;
using WebApi_Param_Odev.Application.GenreOperations.Queries.GetGenres;
using WebApi_Param_Odev.Application.UserOperations.Command.CreateUser;
using WebApi_Param_Odev.Entities;

namespace WebApi_Param_Odev.Common
{
    public class MappingProfile : Profile // profile yi kalıtım aldık
    {
        public MappingProfile()
        {

            // CreateMap<Source,Target> parametreleri ile çalışır. Bu şu demek; kod içerisinde source ile belirtilen obje tipi target ile belirtilen obje tipine dönüştürülebilir.    


            CreateMap<CreateBookModel, Book>(); // CreatBookModel objesi Book objesine mapleme işlemi yaptık yani 




            //Mapper ile obje özelliklerinin birbirine nasıl map'laneceğini de söyleyebiliriz.

            CreateMap<Book, BookDetailViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name)); // gelen verinin id ile degilde degerinin gelmesini istedigimiz için bu şekilde yazdık. formemberdan sonra ki kısım verileri kullanıcıya nasıl gösterecegimizi belirledigimiz yer 
            // dest=>dest.Genre bu kısmı, opt=>opt.MapFrom(src=>((GenreEnum)src.GenreId).ToString()) burası ile mappleme (MapFrom)
            //(src=>((GenreEnum)src.GenreId).ToString()) ---- degiştirdik src=>src.Genre.Name    yaptık.

            //CreateMap<Book,BookDetailViewModel>().ForMember(dest=>dest.Author, opt=>opt.MapFrom(src=>src.Author.Name+" "+src.Author.Surname));


            CreateMap<Book, BooksViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));
            //CreateMap<Book,BooksViewModel>().ForMember(dest=>dest.Author, opt=>opt.MapFrom(src=>src.Author.Name+" "+src.Author.Surname));

            //Genre
            CreateMap<Genre, GenresViewModel>();
            CreateMap<Genre, GenreDetailViewModel>();


            //Author    
            CreateMap<Author, AuthorsViewModel>();
            CreateMap<Author, AuthorsDetailViewModel>();
            CreateMap<CreateAuthorModel, Author>();


            //User
            CreateMap<CreateUserModel, User>();


        }

    }
}
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using WebApi_Param_Odev.DBOperations;

namespace WebApi_Param_Odev.Application.BookOperation.Queries.GetBookDetail
{
    public class GetBookDetailQuery
    {
        private readonly IBookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public int BookId { get; set; }
        public GetBookDetailQuery(IBookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public BookDetailViewModel Handle()
        {
            var book = _dbContext.Books.Include(x => x.Genre).Where(x => x.Id == BookId).SingleOrDefault();//Genre tablosunu da include ettik. çünkü bu alanda genre bilgisi kullanılıyor yani kullanıcıya ganre bilgisi de gösteriliyor
            if (book is null)
            {
                throw new InvalidOperationException("Kitap bulunamadı.");
            }
            BookDetailViewModel vs = _mapper.Map<BookDetailViewModel>(book); //new BookDetailViewModel();
           
            return vs;
        }
    }


    public class BookDetailViewModel
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        //public string Author { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }


    }
}
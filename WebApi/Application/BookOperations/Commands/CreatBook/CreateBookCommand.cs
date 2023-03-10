using AutoMapper;
using System;
using System.Linq;
using WebApi_Param_Odev.DBOperations;
using WebApi_Param_Odev.Entities;

namespace WebApi.Application.BookOperation.Command.CreatBook
{
    public class CreateBookCommand
    {
        public CreateBookModel Model { get; set; }
        private readonly IBookStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateBookCommand(IBookStoreDbContext dBContext, IMapper mapper)
        {
            _dbContext = dBContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var book = _dbContext.Books.SingleOrDefault(x => x.Title == Model.Title);//listede aynı isimden veri var mı diye bakıyor.

            if (book is not null)
            {
                throw new InvalidOperationException("Kitap Zaten Mevcut");
            }
            book = _mapper.Map<Book>(Model); // bu sayede asagıdaki kod satırlarını yazmaya gerek kalmıyor //new Book();
          
            _dbContext.Books.Add(book);
            _dbContext.SaveChanges();//kaydetme işlemi için, save etmek       
        }
    }

    public class CreateBookModel
    {
        public string Title { get; set; }
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }
        public int GenreId { get; set; }

    }
}
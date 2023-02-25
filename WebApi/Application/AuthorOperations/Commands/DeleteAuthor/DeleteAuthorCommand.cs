using System;
using System.Linq;
using WebApi_Param_Odev.DBOperations;

namespace WebApi_Param_Odev.Application.AuthorOperation.Commands.DeleteAuthor
{
    public class DeleteAuthorCommand
    {
        public int authorId { get; set; }
        private readonly IBookStoreDbContext _context;
        public DeleteAuthorCommand(IBookStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var author = _context.Authors.SingleOrDefault(x => x.Id == authorId);
            if (author is null)
                throw new InvalidOperationException("Silinecek yazar bulunamadı.");

            _context.Authors.Remove(author);
            _context.SaveChanges();
        }
    }
}
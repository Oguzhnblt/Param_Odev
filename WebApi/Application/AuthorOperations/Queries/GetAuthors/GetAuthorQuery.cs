using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApi_Param_Odev.DBOperations;
using WebApi_Param_Odev.Entities;

namespace WebApi_Param_Odev.Application.AuthorOperation.Queries.GetAuthors
{
    public class GetAuthorQuery
    {
        private readonly IBookStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAuthorQuery(IBookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<AuthorsViewModel> Handle()
        {
            var authors = _dbContext.Authors.OrderBy(x => x.Id);
            List<AuthorsViewModel> returnObj = _mapper.Map<List<AuthorsViewModel>>(authors);
            return returnObj;
        }
    }

    public class AuthorsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public String DateOfBirth { get; set; }
        public List<Book> Books { get; set; }

    }
}

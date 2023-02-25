
using AutoMapper;
using FluentAssertions;
using System;
using System.Linq;
using TestSetup;
using WebApi_Param_Odev.Application.GenreOperations.Queries.GetGenreDetail;
using WebApi_Param_Odev.DBOperations;
using Xunit;

namespace Application.GenreOperations.Queries
{
    public class GetGenreDetailQueryTests:IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDBContext _context;
        private readonly IMapper _mapper;

        public GetGenreDetailQueryTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenGivenGenreIdIsNotinDB_InvalidOperationException_ShouldBeReturn()
        {
            GetGenreDetailQuery query = new GetGenreDetailQuery(_mapper,_context);
            query.GenreId=0;

            FluentActions.Invoking(() => query.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should()
                .Be("Kitap Türü Bulunamadı.");
        }

        [Fact]
        public void WhenGivenGenreIdIsinDB_InvalidOperationException_ShouldBeReturn()
        {
            GetGenreDetailQuery query = new GetGenreDetailQuery(_mapper,_context);
            query.GenreId=1;

            var genre=_context.Books.SingleOrDefault(genre=>genre.Id == query.GenreId);
            genre.Should().NotBeNull();
        }
    }
}
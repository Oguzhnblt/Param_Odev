using AutoMapper;
using FluentAssertions;
using System;
using System.Linq;
using TestSetup;
using WebApi_Param_Odev.Application.AuthorOperations.Queries.GetAuthorDetail;
using WebApi_Param_Odev.DBOperations;
using Xunit;

namespace Application.AuthorOperations.Queries
{
    public class GetAuthorDetailQueryTests:IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDBContext _context;
        private readonly IMapper _mapper;

        public GetAuthorDetailQueryTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenGivenAuthorIdIsNotinDB_InvalidOperationException_ShouldBeReturn()
        {
            GetAuthorDetailQuery query = new GetAuthorDetailQuery(_context,_mapper);
            query.AuthorId=0;

            FluentActions.Invoking(() => query.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should()
                .Be("Yazar Bulunamad─▒.");
        }

        [Fact]
        public void WhenGivenAuthorIdIsinDB_InvalidOperationException_ShouldBeReturn()
        {
            GetAuthorDetailQuery query = new GetAuthorDetailQuery(_context,_mapper);
            query.AuthorId=1;

            FluentActions.Invoking(() => query.Handle()).Invoke();

            var author=_context.Authors.SingleOrDefault(author=>author.Id == query.AuthorId);
            author.Should().NotBeNull();
        }
    }
}

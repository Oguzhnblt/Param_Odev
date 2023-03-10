using FluentAssertions;
using System;
using System.Linq;
using TestSetup;
using WebApi_Param_Odev.Application.UpdateOperation.Command.UpdateAuthor;
using WebApi_Param_Odev.DBOperations;
using Xunit;

namespace Application.AuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAuthorCommandTests:IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDBContext _context;

        public UpdateAuthorCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }

        [Fact]
        public void WhenGivenAuthorIdIsNotinDB_InvalidOperationException_ShouldBeReturn()
        {
            UpdateAuthorCommand command = new UpdateAuthorCommand(_context);
            command.Authorid=0;

            FluentActions.Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Yazar Bulunamad─▒.");
        }

        [Fact]
        public void WhenGivenAuthorIdIsinDB_InvalidOperationException_ShouldBeReturn()
        {
            UpdateAuthorCommand command = new UpdateAuthorCommand(_context);
            command.Model = new UpdateAuthorModel(){Name = "Sigmund", Surname="Freud", DateOfBirth="06.05.1856"};
            command.Authorid=1;

            FluentActions.Invoking(() => command.Handle()).Invoke();
            
            var author=_context.Authors.SingleOrDefault(author=>author.Id == command.Authorid);
            author.Should().NotBeNull(null);
        }
    }
}

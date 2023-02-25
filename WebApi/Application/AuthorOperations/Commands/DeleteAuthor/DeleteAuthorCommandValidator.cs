using FluentValidation;

namespace WebApi_Param_Odev.Application.AuthorOperation.Commands.DeleteAuthor
{
    public class DeleteAuthorCommandValidator : AbstractValidator<DeleteAuthorCommand>
    {
        public DeleteAuthorCommandValidator()
        {
            RuleFor(command => command.authorId).GreaterThan(0).NotEmpty();
        }
    }
}
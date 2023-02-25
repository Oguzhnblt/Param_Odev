using FluentValidation;
using WebApi_Param_Odev.Application.AuthorOperations.Commands.CreateAuthor;

namespace WebApi_Param_Odev.Application.AuthorOperation.Commands.CreatAuthor
{
    public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
    {
        public CreateAuthorCommandValidator()
        {
            RuleFor(command => command.Model.Name).NotEmpty().MinimumLength(3);
            RuleFor(command => command.Model.Surname).NotEmpty().MinimumLength(3);
        }
    }
}
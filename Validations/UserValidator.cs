using System.Data;
using anketdeneme.Models;
using FluentValidation;

namespace anketdeneme.Validations
{
    public class UserValidator : AbstractValidator<Users>
    {
        public UserValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim alanı boş bırakılamaz");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Parola boş bırakılamaz.");
        }

    }
}
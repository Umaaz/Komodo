using FluentValidation;
using Komodo.Core.Types.Model;

namespace Komodo.Core.Database.Validations
{
    public class FilmValidator : AbstractValidator<Film>
    {
        public FilmValidator()
        {
            RuleFor(x => x.Title).NotNull().NotEmpty().Must(BeLessThanOrEqualTo100).WithMessage(
                "Title: Must be less than 100 char long, and not null or empty");
            RuleFor(x => x.Synopsis).Must(BeLessThanOrEqualTo2000).WithMessage("Synopsis: Must be less than 2000");
        }

        private bool BeLessThanOrEqualTo2000(string str)
        {
            if (str != null)
                return str.Length < 2000;
            return false;
        }

        private bool BeLessThanOrEqualTo100(string str)
        {
            if (str != null)
                return str.Length < 100;
            return false;
        }
    }
}

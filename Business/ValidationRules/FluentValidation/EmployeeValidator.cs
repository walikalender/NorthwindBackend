using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class EmployeeValidator : AbstractValidator<Employee>
    {
        public EmployeeValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.FirstName).MinimumLength(2);

            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.LastName).MinimumLength(2);

            RuleFor(e => e.BirthDate).Must(BeValidDate).WithMessage("Geçerli bir doğum tarihi girilmelidir.");
            RuleFor(e => e.HireDate).Must(BeValidDate).WithMessage("Geçerli bir işe giriş tarihi girilmelidir.");
        }

        private bool BeValidDate(DateTime date)
        {
            return !date.Equals(default(DateTime));
        }
    }
}

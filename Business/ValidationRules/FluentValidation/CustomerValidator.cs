using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(c => c.CompanyName).NotEmpty();
            RuleFor(c => c.CompanyName).MinimumLength(2);
            RuleFor(c => c.CompanyName).MaximumLength(40);

            RuleFor(c => c.ContactName).NotEmpty().MinimumLength(2);
            RuleFor(c => c.ContactName).MinimumLength(2);

            RuleFor(c => c.Address).NotEmpty().MinimumLength(5);
            RuleFor(c => c.Address).MinimumLength(5);

            RuleFor(c => c.Phone).MinimumLength(7);
            RuleFor(c => c.Phone).NotEmpty().MinimumLength(7);

        }
    }
}

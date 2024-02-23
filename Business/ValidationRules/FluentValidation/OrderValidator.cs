using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class OrderValidator : AbstractValidator<Order>
    {
        public OrderValidator()
        {
            RuleFor(o => o.CustomerID).NotEmpty().MinimumLength(1);

            RuleFor(o => o.EmployeeID).NotEmpty().GreaterThan(0);

            RuleFor(o => o.OrderDate).Must(BeValidDate).WithMessage("Geçerli bir sipariş tarihi girilmelidir.");
            RuleFor(o => o.OrderDate).NotEmpty().WithMessage("Geçerli bir sipariş tarihi girilmelidir.");

            RuleFor(o => o.Customer).NotNull().WithMessage("Sipariş müşterisi belirtilmelidir.");

            RuleFor(o => o.Employee).NotNull().WithMessage("Siparişi oluşturan çalışan belirtilmelidir.");

            RuleFor(o => o.OrderDetails).NotEmpty().WithMessage("Sipariş detayları belirtilmelidir.");
        }
        private bool BeValidDate(DateTime date)
        {
            return !date.Equals(default(DateTime));
        }
    }
}

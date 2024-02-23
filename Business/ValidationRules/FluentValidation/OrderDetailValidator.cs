using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class OrderDetailValidator : AbstractValidator<OrderDetail>
    {
        public OrderDetailValidator()
        {
            RuleFor(od => od.OrderID).NotEmpty().GreaterThan(0);
            RuleFor(od => od.OrderID).NotEmpty();

            RuleFor(od => od.ProductID).NotEmpty().GreaterThan(0);
            RuleFor(od => od.ProductID).NotEmpty();

            RuleFor(od => od.UnitePrice).NotEmpty().GreaterThan(0);
            RuleFor(od => od.UnitePrice).NotEmpty();

            RuleFor(od => od.Quantity).NotEmpty().GreaterThan((short)0);
            RuleFor(od => od.Quantity).NotEmpty();

            RuleFor(od => od.Product).NotNull().WithMessage("Sipariş detayı ürünü belirtilmelidir.");
            RuleFor(od => od.Order).NotNull().WithMessage("Sipariş detayı siparişi belirtilmelidir.");
        }
    }
}

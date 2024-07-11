using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using TestSeriLog.Models;

namespace TestSeriLog.Utils.Validators
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(product => product.name).NotNull().WithMessage("Name must not be null");
            RuleFor(product => product.name).Matches("^[a-zA-Z0-9 ]*$").WithMessage("Name must not contain special character");
            RuleFor(product => product.quantity).GreaterThan(0).WithMessage("Quantity must greater than 0");
            RuleFor(product => product.quantity).NotNull().WithMessage("Quantity must not be null");
        }
    }
}
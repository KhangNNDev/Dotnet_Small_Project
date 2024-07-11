using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.Extensions.Options;
using TestSeriLog.Exceptions;
using TestSeriLog.Models;
using TestSeriLog.Utils.Validators;

namespace TestSeriLog.Services.Implementations
{
    public class ProductService : IProductService
    {
        public async Task Add(Product product)
        {
            ProductValidator validator = new ProductValidator();
            // ValidationResult result =
            ValidationResult result = validator.Validate(product);
            if (!result.IsValid)
            {
                List<FormError> errorLists = new List<FormError>();
                foreach (ValidationFailure failure in result.Errors)
                {
                    errorLists.Add(new FormError{Property = failure.PropertyName,ErrorMessage = failure.ErrorMessage});
                }
                throw new APIException((int)HttpStatusCode.BadRequest, "Add Product Failed",errorLists);
            }
        }
    }
}
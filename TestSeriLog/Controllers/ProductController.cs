using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TestSeriLog.Models;
using TestSeriLog.Services;

namespace TestSeriLog.Controllers
{
    [Route("api/v1/product")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductService _productService;

        public ProductController(ILogger<ProductController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        [HttpPost]
        public async Task<IActionResult> TestValidate([FromBody] Product product)
        {
            await _productService.Add(product);

            return Ok();
        }
    }
}
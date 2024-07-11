using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestSeriLog.Models;

namespace TestSeriLog.Services
{
    public interface IProductService
    {
        Task Add(Product product);
    }
}
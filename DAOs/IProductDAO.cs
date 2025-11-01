using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task.Models;

namespace Task.DAOs
{
    public interface IProductDAO
    {
        IEnumerable<Product> GetAllProducts();
        Product? GetProductById(int productId);
    }
}
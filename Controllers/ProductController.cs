using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Task.DAOs;
using Task.Models;

namespace Task.Controllers
{
    [ApiController]
    [Route("/testapp/api/v1/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ProductDAO _productDAO;

        public ProductsController(IConfiguration configuration)
        {
            _productDAO = new ProductDAO(configuration);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetAllProducts()  => Ok(_productDAO.GetAllProducts());

        [HttpGet("{id}")]
        public ActionResult<Product?> GetProductById(int id)  => Ok(_productDAO.GetProductById(id));
    }
}
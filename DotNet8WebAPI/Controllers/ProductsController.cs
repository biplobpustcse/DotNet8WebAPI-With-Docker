using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DotNet8WebAPI.Data;
using DotNet8WebAPI.Model;
using DotNet8WebAPI.Services.Interface;

namespace DotNet8WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService productService;
        public ProductsController(IProductService _productService)
        {
            productService = _productService;
        }
        [HttpGet]
        public async Task<IEnumerable<Product>> ProductList()
        {
            var productList = await productService.GetProductList();
            return productList;

        }
        [HttpGet("{id}")]
        public async Task<Product> GetProductById(int id)
        {
            return await productService.GetProductById(id);
        }
        [HttpPost]
        public async Task<Product> AddProduct(Product product)
        {
            return await productService.AddProduct(product);
        }
        [HttpPut]
        public async Task<Product> UpdateProduct(Product product)
        {
            return await productService.UpdateProduct(product);
        }
        [HttpDelete("{id}")]
        public async Task<bool> DeleteProduct(int id)
        {
            return await productService.DeleteProduct(id);
        }
    }
}

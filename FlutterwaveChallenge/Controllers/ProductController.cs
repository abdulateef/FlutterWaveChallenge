using FlutterwaveChallenge.Entities;
using FlutterwaveChallenge.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlutterwaveChallenge.Controllers
{
    [Route("api/V1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        [HttpGet]
        [Route("GetProducts")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var result = await _productRepository.GetProducts();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("GetProductById")]
        [HttpGet]
        public async Task<ActionResult<Product>> GetProductById(string id)
        {
            var result = await _productRepository.GetProduct(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet]
        [Route("GetProductByName")]
        public async Task<ActionResult<Product>> GetProductByName(string name)
        {
            var result = await _productRepository.GetProductByName(name);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("GetProductByCategoryName")]
        [HttpGet]
        public async Task<ActionResult<Product>> GetProductByCategoryName(string categoryName)
        {
            var result = await _productRepository.GetProductByCategory(categoryName);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Update")]
        [HttpPut]
        public async Task<ActionResult<bool>> Update(Product product)
        {
            var result = await _productRepository.Update(product);
            return Ok(result);
        }

        [Route("Delete")]
        [HttpDelete]
        public async Task<ActionResult<bool>> Delete(string id)
        {
            var result = await _productRepository.Delete(id);
            return Ok(result);
        }
        [Route("CreateProduct")]
        [HttpPost]
        public async Task<ActionResult<Product>> Create([FromBody] Product product)
        {
            await _productRepository.Create(product);
            return CreatedAtRoute("GetProductById", new { id = product.Id }, product);
        }
    }
}

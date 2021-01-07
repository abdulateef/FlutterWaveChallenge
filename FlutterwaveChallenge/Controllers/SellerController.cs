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
    public class SellerController : ControllerBase
    {
        private ISellerRepository _sellerRepository;
        public SellerController(ISellerRepository sellerRepository)
        {
            _sellerRepository = sellerRepository;
        }
        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<IEnumerable<Seller>>> GetAll()
        {
            var result = await _sellerRepository.GetAll();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Get")]
        [HttpGet]
        public async Task<ActionResult<Seller>> GetById(string id)
        {
            var result = await _sellerRepository.Get(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet]
        [Route("GetByName")]
        public async Task<ActionResult<Seller>> GetProductByName(string name)
        {
            var result = await _sellerRepository.GetByName(name);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }



        [Route("Update")]
        [HttpPut]
        public async Task<ActionResult<bool>> Update(Seller seller)
        {
            var result = await _sellerRepository.Update(seller);
            return Ok(result);
        }

        [Route("Delete")]
        [HttpDelete]
        public async Task<ActionResult<bool>> Delete(string id)
        {
            var result = await _sellerRepository.Delete(id);
            return Ok(result);
        }
        [Route("Create")]
        [HttpPost]
        public async Task<ActionResult<Seller>> Create([FromBody] Seller seller)
        {
            await _sellerRepository.Create(seller);
            var result = await _sellerRepository.GetByName(seller.ShopName);
            return Ok(result);
        }
    }
}

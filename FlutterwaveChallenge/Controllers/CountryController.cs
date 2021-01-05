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
    public class CountryController : ControllerBase
    {
        private readonly ICountryRepository _countryRepository;
        public CountryController(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }
        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<IEnumerable<Country>>> GetAll()
        {
            var result = await _countryRepository.GetAll();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Get")]
        [HttpGet]
        public async Task<ActionResult<Country>> GeById(string id)
        {
            var result = await _countryRepository.Get(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet]
        [Route("GetByName")]
        public async Task<ActionResult<Country>> GetProductByName(string name)
        {
            var result = await _countryRepository.GetByName(name);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

      

        [Route("Update")]
        [HttpPut]
        public async Task<ActionResult<bool>> Update(Country country)
        {
            var result = await _countryRepository.Update(country);
            return Ok(result);
        }

        [Route("Delete")]
        [HttpDelete]
        public async Task<ActionResult<bool>> Delete(string id)
        {
            var result = await _countryRepository.Delete(id);
            return Ok(result);
        }
        [Route("Create")]
        [HttpPost]
        public async Task<ActionResult<Product>> Create([FromBody] Country country)
        {
            await _countryRepository.Create(country);
            return CreatedAtRoute("Get", new { id = country.Id }, country);
        }
    }
}

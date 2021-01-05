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
    public class RiderController : ControllerBase
    { 

        private readonly IRiderRepository _riderRepository;
        public RiderController(IRiderRepository riderRepository)
        {
            _riderRepository = riderRepository;
        }
        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<IEnumerable<Rider>>> GetAll()
        {
            var result = await _riderRepository.GetAll();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Get")]
        [HttpGet]
        public async Task<ActionResult<Rider>> GetById(string id)
        {
            var result = await _riderRepository.Get(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet]
        [Route("GetByName")]
        public async Task<ActionResult<Rider>> GetByName(string name)
        {
            var result = await _riderRepository.GetByName(name);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }



        [Route("Update")]
        [HttpPut]
        public async Task<ActionResult<bool>> Update(Rider rider)
        {
            var result = await _riderRepository.Update(rider);
            return Ok(result);
        }

        [Route("Delete")]
        [HttpDelete]
        public async Task<ActionResult<bool>> Delete(string id)
        {
            var result = await _riderRepository.Delete(id);
            return Ok(result);
        }
        [Route("Create")]
        [HttpPost]
        public async Task<ActionResult<Rider>> Create([FromBody] Rider rider)
        {
            await _riderRepository.Create(rider);
            return CreatedAtRoute("Get", new { id = rider.Id }, rider);
        }
    }
}

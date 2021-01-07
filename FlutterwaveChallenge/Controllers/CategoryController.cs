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
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<IEnumerable<Category>>> GetAll()
        {
            var result = await _categoryRepository.GetAll();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Get")]
        [HttpGet]
        public async Task<ActionResult<Category>> GetById(string id)
        {
            var result = await _categoryRepository.Get(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet]
        [Route("GetByName")]
        public async Task<ActionResult<Category>> GetByName(string name)
        {
            var result = await _categoryRepository.GetByName(name);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }



        [Route("Update")]
        [HttpPut]
        public async Task<ActionResult<bool>> Update(Category category)
        {
            var result = await _categoryRepository.Update(category);
            return Ok(result);
        }

        [Route("Delete")]
        [HttpDelete]
        public async Task<ActionResult<bool>> Delete(string id)
        {
            var result = await _categoryRepository.Delete(id);
            return Ok(result);
        }
        [Route("Create")]
        [HttpPost]
        public async Task<ActionResult<Category>> Create([FromBody] Category category)
        {
            await _categoryRepository.Create(category);
            var result = await _categoryRepository.GetByName(category.Name);
            return Ok(result);
        }
    }
}

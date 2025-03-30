using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Psychological.Repository.Models;
using Psychological.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Psychological_APIServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServeyCategoriesController : ControllerBase
    {
        private readonly ISurveyCategoryService _surveyCategoryService;
        public ServeyCategoriesController(ISurveyCategoryService surveyCategoryService)
        {
            _surveyCategoryService = surveyCategoryService;
        }

        // GET: api/<ServeyCategoriesController>
        [HttpGet]
        public async Task<IEnumerable<ServeyCategory>> Get()
        {
            return await _surveyCategoryService.GetAll();
        }

        // GET api/<ServeyCategoriesController>/5
        [HttpGet("{id}")]
        public async Task<ServeyCategory> GetById(int id)
        {
            return await _surveyCategoryService.GetById(id);
        }

        // POST api/<ServeyCategoriesController>
        [HttpPost]
        public async Task<int> Post([FromBody] ServeyCategory value)
        {
            return await _surveyCategoryService.Create(value);
        }

        // PUT api/<ServeyCategoriesController>/5
        [HttpPut("{id}")]
        public async Task<int> Put(int id, [FromBody] ServeyCategory serveyCategory)
        {
            return await _surveyCategoryService.Update(serveyCategory);
        }

        // DELETE api/<ServeyCategoriesController>/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            return await _surveyCategoryService.Delete(id);
        }
    }
}

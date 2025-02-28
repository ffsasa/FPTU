using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Psychological.Repository.Models;
using Psychological.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Psychological.BlazorApp.APIService
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
        [Authorize(Roles = "1,2")]
        public async Task<ServeyCategory> GetById(int id)
        {
            return await _surveyCategoryService.GetById(id);
        }

        // POST api/<ServeyCategoriesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ServeyCategoriesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ServeyCategoriesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using PE_PRN231_SP25_00259_QE170035_Repository.Models;
using PE_PRN231_SP25_00259_QE170035_Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PE_PRN231_SP25_00259_QE170035_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HandbagController : ControllerBase
    {
        private readonly IHandbagService _handbagService;
        public HandbagController(IHandbagService handbagService)
        {
            _handbagService = handbagService;
        }

        // GET: api/<SurveyController>
        [HttpGet]
        [EnableQuery]
        [Authorize(Roles = "2")]
        public async Task<IEnumerable<Handbag>> Get()
        {
            return await _handbagService.GetAll();
        }

        // GET api/<SurveyController>/5
        [HttpGet("{id}")]
        [EnableQuery]
        [Authorize(Roles = "2")]
        public async Task<Handbag> GetById(int id)
        {
            return await _handbagService.GetById(id);
        }

        [HttpGet("search")]
        [EnableQuery]
        [Authorize(Roles = "2, 3, 4")]
        public async Task<IEnumerable<Handbag>> Search(string? Color, string? ModelName, string? Material)
        {
            return await _handbagService.SearchAsync(Color, ModelName, Material);
        }

        // POST api/<SurveyController>
        [HttpPost]
        [EnableQuery]
        [Authorize(Roles = "2")]
        public async Task<int> Post(Handbag handbag)
        {
            return await _handbagService.Create(handbag);
        }

        // PUT api/<SurveyController>/5
        [HttpPut("{id}")]
        [EnableQuery]
        [Authorize(Roles = "2")]
        public async Task<int> Put(int id, [FromBody] Handbag handbag)
        {
            return await _handbagService.Update(handbag);
        }

        // DELETE api/<SurveyController>/5
        [HttpDelete("{id}")]
        [EnableQuery]
        [Authorize(Roles = "2")]
        public async Task<bool> Delete(int id)
        {
            return await _handbagService.Delete(id);
        }
    }
}

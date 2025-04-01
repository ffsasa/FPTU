using Microsoft.AspNetCore.Mvc;
using PE_PRN231_SP25_00259_QE170035_Repository.Models;
using PE_PRN231_SP25_00259_QE170035_Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PE_PRN231_SP25_00259_QE170035_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _brandService;
        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        // GET: api/<ServeyCategoriesController>
        [HttpGet]
        public async Task<IEnumerable<Brand>> Get()
        {
            return await _brandService.GetAll();
        }

        // GET api/<ServeyCategoriesController>/5
        [HttpGet("{id}")]
        public async Task<Brand> GetById(int id)
        {
            return await _brandService.GetById(id);
        }
    }
}

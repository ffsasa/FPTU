using BusinessObject.Shared.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ServeyCategory.Microservices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServeyCategoryController : ControllerBase
    {
        private static List<BusinessObject.Shared.Models.ServeyCategory> _categories = new List<BusinessObject.Shared.Models.ServeyCategory>
        {
            new BusinessObject.Shared.Models.ServeyCategory { Id = 1, Name = "Category 1", CreateAt = DateTime.UtcNow },
            new BusinessObject.Shared.Models.ServeyCategory { Id = 2, Name = "Category 2", CreateAt = DateTime.UtcNow }
        };

        // GET: api/ServeyCategory
        [HttpGet]
        public ActionResult<IEnumerable<BusinessObject.Shared.Models.ServeyCategory>> Get()
        {
            return Ok(_categories);
        }

        // GET api/ServeyCategory/5
        [HttpGet("{id}")]
        public ActionResult<BusinessObject.Shared.Models.ServeyCategory> Get(int id)
        {
            var category = _categories.FirstOrDefault(c => c.Id == id);
            if (category == null) return NotFound();
            return Ok(category);
        }

        // POST api/ServeyCategory
        [HttpPost]
        public ActionResult Post([FromBody] BusinessObject.Shared.Models.ServeyCategory category)
        {
            category.Id = _categories.Count + 1;
            category.CreateAt = DateTime.UtcNow;
            _categories.Add(category);
            return CreatedAtAction(nameof(Get), new { id = category.Id }, category);
        }

        // PUT api/ServeyCategory/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] BusinessObject.Shared.Models.ServeyCategory updatedCategory)
        {
            var category = _categories.FirstOrDefault(c => c.Id == id);
            if (category == null) return NotFound();

            category.Name = updatedCategory.Name;
            category.UpdateAt = DateTime.UtcNow;
            return NoContent();
        }

        // DELETE api/ServeyCategory/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var category = _categories.FirstOrDefault(c => c.Id == id);
            if (category == null) return NotFound();

            _categories.Remove(category);
            return NoContent();
        }
    }
}

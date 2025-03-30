using BusinessObject.Shared.Models;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Survey.Microservices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IBus _bus;

        public SurveyController(IBus bus, ILogger<SurveyController> logger)
        {
            _bus = bus;
            _logger = logger;
        }

        private static List<BusinessObject.Shared.Models.Survey> _surveys = new List<BusinessObject.Shared.Models.Survey>
        {
            new BusinessObject.Shared.Models.Survey { Id = 1, CategoryId = 1, Description = "Khảo sát 1", Number = 10, PointAverage = 4.5, CreateBy = 1, CreateAt = DateTime.UtcNow },
            new BusinessObject.Shared.Models.Survey { Id = 2, CategoryId = 2, Description = "Khảo sát 2", Number = 15, PointAverage = 3.8, CreateBy = 2, CreateAt = DateTime.UtcNow }
        };

        // GET: api/Survey
        [HttpGet]
        public ActionResult<IEnumerable<BusinessObject.Shared.Models.Survey>> Get()
        {
            return Ok(_surveys);
        }

        // GET api/Survey/5
        [HttpGet("{id}")]
        public ActionResult<BusinessObject.Shared.Models.Survey> Get(int id)
        {
            var survey = _surveys.FirstOrDefault(s => s.Id == id);
            if (survey == null) return NotFound();
            return Ok(survey);
        }

        // POST api/Survey
        [HttpPost]
        public ActionResult Post([FromBody] BusinessObject.Shared.Models.Survey survey)
        {
            survey.Id = _surveys.Count + 1;
            survey.CreateAt = DateTime.UtcNow;
            _surveys.Add(survey);
            return CreatedAtAction(nameof(Get), new { id = survey.Id }, survey);
        }

        // PUT api/Survey/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] BusinessObject.Shared.Models.Survey updatedSurvey)
        {
            var survey = _surveys.FirstOrDefault(s => s.Id == id);
            if (survey == null) return NotFound();

            survey.CategoryId = updatedSurvey.CategoryId;
            survey.Description = updatedSurvey.Description;
            survey.Number = updatedSurvey.Number;
            survey.PointAverage = updatedSurvey.PointAverage;
            survey.Verygood = updatedSurvey.Verygood;
            survey.Good = updatedSurvey.Good;
            survey.Medium = updatedSurvey.Medium;
            survey.Bad = updatedSurvey.Bad;
            survey.VeryBad = updatedSurvey.VeryBad;
            survey.UpdateAt = DateTime.UtcNow;
            return NoContent();
        }

        // DELETE api/Survey/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var survey = _surveys.FirstOrDefault(s => s.Id == id);
            if (survey == null) return NotFound();

            _surveys.Remove(survey);
            return NoContent();
        }
    }
}

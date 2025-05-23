﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Psychological.Repository.Models;
using Psychological.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Psychological.BlazorApp.APIService
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyController : ControllerBase
    {
        private readonly ISurveyService _surveyService;
        public SurveyController(ISurveyService surveyService)
        {
            _surveyService = surveyService;
        }

        // GET: api/<SurveyController>
        [HttpGet]
        //[Authorize(Roles = "1,2")]
        public async Task<IEnumerable<Survey>> Get()
        {
            return await _surveyService.GetAll();
        }

        // GET api/<SurveyController>/5
        [HttpGet("{id}")]
        public async Task<Survey> GetById(int id)
        {
            return await _surveyService.GetById(id);
        }

        [HttpGet("(Name)/(Number)/(Verygood)")]
        public async Task<IEnumerable<Survey>> Search(string Name, int Number, int Verygood)
        {
            return await _surveyService.SearchAsync(Name, Number, Verygood);
        }

        // POST api/<SurveyController>
        [HttpPost]
        public async Task<int> Post(Survey survey)
        {
            Random random = new Random();
            survey.Id = random.Next(0, 100000);
            return await _surveyService.Create(survey);
        }

        // PUT api/<SurveyController>/5
        [HttpPut("{id}")]
        public async Task<int> Put(int id, [FromBody] Survey survey)
        {
            survey.UpdateAt = DateTime.Now;
            return await _surveyService.Update(survey);
        }

        // DELETE api/<SurveyController>/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            return await _surveyService.Delete(id);
        }
    }
}

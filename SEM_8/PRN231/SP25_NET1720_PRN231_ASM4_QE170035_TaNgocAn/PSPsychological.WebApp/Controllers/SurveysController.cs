using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Server;
using Microsoft.AspNetCore.Mvc;
using PSPsychological.WebApp.DTO;
using PSPsychological.WebApp.Services;
using Psychological.Repository.Models;

namespace PSPsychological.WebApp.Controllers
{
    public class SurveysController : Controller
    {
        private readonly IGraphQLExecutor _graphQLExecutor;  // GraphQL Executor

        public SurveysController(IGraphQLExecutor graphQLExecutor)
        {
            _graphQLExecutor = graphQLExecutor;
        }

        // GET: Surveys
        public async Task<IActionResult> Index()
        {
            var query = @"
            {
                surveys {
                    id
                    description
                    categoryId
                    number
                    pointAverage
                    verygood
                    good
                    medium
                    bad
                    veryBad
                    createBy
                    createAt
                    updateAt
                    category {
                        id
                    }
                }
            }";

            // Execute GraphQL query và nhận về một danh sách SurveyDTO
            var result = await _graphQLExecutor.ExecuteQuery<SurveyDataWrapper>(query);
            return View(result.Surveys);  // Trả về View với danh sách surveys DTO
        }


        // POST: Create Survey using GraphQL
        [HttpPost]
        public async Task<IActionResult> CreateSurvey(string description, int categoryId, int number, double pointAverage, int verygood, int good, int medium, int bad, int veryBad)
        {
            var mutation = $@"
            mutation {{
                createSurvey(description: ""{description}"", categoryId: {categoryId}, number: {number}, pointAverage: {pointAverage}, verygood: {verygood}, good: {good}, medium: {medium}, bad: {bad}, veryBad: {veryBad}) {{
                    id
                    description
                }}
            }}";

            var result = await _graphQLExecutor.ExecuteMutation<Survey>(mutation);
            return RedirectToAction(nameof(Index)); // Điều hướng lại về trang danh sách surveys
        }

        // POST: Delete Survey using GraphQL
        [HttpPost]
        public async Task<IActionResult> DeleteSurvey(int id)
        {
            var mutation = $@"
            mutation {{
                deleteSurvey(id: {id})
            }}";

            var result = await _graphQLExecutor.ExecuteMutation<Survey>(mutation);
            return RedirectToAction(nameof(Index)); // Điều hướng lại về trang danh sách surveys
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Server;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        [HttpGet]
        public async Task<IActionResult> CreateSurvey()
        {
            var query = @"
            {
                categories {
                    id
                    name
                    createAt
                    updateAt
                  }
            }";

            var result = await _graphQLExecutor.ExecuteQuery<CategoryDataWrapper>(query);

            ViewBag.CategoryId = new SelectList(result?.Categories ?? new List<CategoryDTO>(), "Id", "Name");
            return View();
        }

        // POST: Create Survey using GraphQL
        [HttpPost]
        public async Task<IActionResult> Create(int id, string description, int categoryId, int number, double pointAverage, int verygood, int good, int medium, int bad, int veryBad)
        {
            var mutation = $@"
                mutation {{
                    createSurvey(
                        id: {id},
                        description: ""{description}"",
                        categoryId: {categoryId},
                        number: {number},
                        pointAverage: {pointAverage},
                        verygood: {verygood},
                        good: {good},
                        medium: {medium},
                        bad: {bad},
                        veryBad: {veryBad}
                    ) {{
                        id
                        description
                    }}
                }}";

            var response = await _graphQLExecutor.ExecuteQuery<dynamic>(mutation);

            if (response?.errors != null)
            {
                Console.WriteLine("GraphQL Errors:");
                foreach (var error in response.errors)
                {
                    Console.WriteLine(error.message);
                }
            }

            return RedirectToAction(nameof(Index));
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

        // GET: Surveys/EditSurvey/5
        [HttpGet]
        public async Task<IActionResult> EditSurvey(int id)
        {
            var query = $@"
            {{
                survey(id: {id}) {{
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
                    category {{
                        id
                        name
                    }}
                }}
            }}";

            var result = await _graphQLExecutor.ExecuteQuery<SurveyDTO>(query);

            if (result != null)
            {
                var categoryResult = await _graphQLExecutor.ExecuteQuery<CategoryDataWrapper>(
                    "{ categories { id name } }"
                );

                ViewBag.CategoryId = new SelectList(categoryResult?.Categories, "Id", "Name");

                return View(result);
            }
            else
            {
                return NotFound();  // Trả về lỗi nếu không tìm thấy survey.
            }
        }

        // POST: Surveys/EditSurvey/5
        [HttpPost]
        public async Task<IActionResult> EditSurvey(int id, SurveyDTO survey)
        {
            if (ModelState.IsValid)
            {
                var mutation = $@"
                mutation {{
                    updateSurvey(id: {id}, description: ""{survey.Description}"", categoryId: {survey.CategoryId}, number: {survey.Number}, pointAverage: {survey.PointAverage}, verygood: {survey.Verygood}, good: {survey.Good}, medium: {survey.Medium}, bad: {survey.Bad}, veryBad: {survey.VeryBad}) {{
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
                        createAt
                        updateAt
                        category {{
                            name
                        }}
                    }}
                }}";

                var result = await _graphQLExecutor.ExecuteMutation<SurveyDTO>(mutation);

                if (result != null)
                {
                    return RedirectToAction(nameof(Index));  // Điều hướng về danh sách Survey
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Failed to update survey.");
                    return View(survey);
                }
            }
            return View(survey);  // Trả về lại trang nếu có lỗi.
        }

    }
}

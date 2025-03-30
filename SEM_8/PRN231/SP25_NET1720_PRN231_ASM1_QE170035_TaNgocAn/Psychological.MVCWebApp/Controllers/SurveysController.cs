using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Psychological.Repository.DBContext;
using Psychological.Repository.Models;

namespace Psychological.MVCWebApp.Controllers
{
    public class SurveysController : Controller
    {
        private string APIEndPoint = "https://localhost:7097/api/";
        public SurveysController() { }

        public async Task<IActionResult> Index()
        {
            using (var httpClient = new HttpClient())
            {
                #region Add Token to header of Request

                var tokenString = HttpContext.Request.Cookies.FirstOrDefault(c => c.Key == "TokenString").Value;

                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + tokenString);

                #endregion


                using (var response = await httpClient.GetAsync(APIEndPoint + "Survey"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<List<Survey>>(content);

                        if (result != null)
                        {
                            return View(result);
                        }
                    }
                }
            }
            return View(new List<Survey>());
        }

        public IActionResult Surveylist()
        {
            return View(); // Kiểm tra xem file Surveylist.cshtml có tồn tại không?
        }

        public async Task<IActionResult> Details(int id)
        {
            using (var httpClient = new HttpClient()) {

                var tokenString = HttpContext.Request.Cookies.FirstOrDefault(c => c.Key == "TokenString").Value;

                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + tokenString);

                using (var response = await httpClient.GetAsync(APIEndPoint + "Survey/" + id))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<Survey>(content);

                        if(result != null) { return View(result); }
                    }

                    ModelState.AddModelError("", "Không thể tải dữ liệu. Vui lòng thử lại!");
                    return View("Error");
                }
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteQuicly(int id)
        {
            bool deleteStatus = false;

            using (var httpClient = new HttpClient())
            {
                var tokenString = HttpContext.Request.Cookies.FirstOrDefault(c => c.Key == "TokenString").Value;
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + tokenString);

                using (var response = await httpClient.DeleteAsync(APIEndPoint + "Survey/" + id))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        deleteStatus = true;
                    }
                }
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: Surveys/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var surveysCategory = new List<ServeyCategory>();

            using (var httpClient = new HttpClient())
            {
                var tokenString = HttpContext.Request.Cookies.FirstOrDefault(c => c.Key == "TokenString").Value;

                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + tokenString);

                using (var response = await httpClient.GetAsync(APIEndPoint + "ServeyCategories"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        surveysCategory = JsonConvert.DeserializeObject<List<ServeyCategory>>(content);
                    }
                }
            }

            using (var httpClient = new HttpClient())
            {
                var tokenString = HttpContext.Request.Cookies.FirstOrDefault(c => c.Key == "TokenString").Value;

                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + tokenString);

                using (var response = await httpClient.GetAsync(APIEndPoint + "Survey/" + id))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<Survey>(content);

                        if (result != null)
                        {
                            ViewData["CategoryId"] = new SelectList(surveysCategory, "Id", "Name", result.CategoryId);
                            return View(result);
                        }
                    }
                   
                }
            }

            if (surveysCategory == null)
            {
                surveysCategory = new List<ServeyCategory>(); // Khởi tạo danh sách trống để tránh lỗi
            }

            ViewData["CategoryId"] = new SelectList(surveysCategory, "Id", "Name");
            return View(new Survey());
        }

        // POST: Surveys/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Survey survey)
        {
            var saveStatus = false;

            if (survey == null)
            {
                // Xử lý nếu survey là null
                survey = new Survey();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    using (var httpClient = new HttpClient())
                    {
                        var tokenString = HttpContext.Request.Cookies.FirstOrDefault(c => c.Key == "TokenString").Value;

                        httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + tokenString);

                        using (var response = await httpClient.PutAsJsonAsync(APIEndPoint + "Survey/" + survey.Id, survey))
                        {
                            if (response.IsSuccessStatusCode)
                            {
                                var content = await response.Content.ReadAsStringAsync();
                                var result = JsonConvert.DeserializeObject<int>(content);

                                if (result > 0)
                                {
                                    saveStatus = true;
                                }
                            }
                            else
                            {
                                // Xử lý khi request không thành công (in ra log hoặc lỗi)
                                var errorContent = await response.Content.ReadAsStringAsync();
                                // Log lỗi ở đây nếu cần
                            }

                        }
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
            }
            if (saveStatus)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                if (survey.CategoryId == null)
                {
                    // Xử lý nếu survey là null
                    survey = new Survey();
                }

                var categories = await this.GetServeyCategory();
                if (categories == null)
                {
                    // Xử lý trường hợp không có danh mục
                    categories = new List<ServeyCategory>();
                }
                ViewData["CategoryId"] = new SelectList(categories, "Id", "Name", survey.CategoryId);
                return View(survey);
            }
        }

        public async Task<List<ServeyCategory>> GetServeyCategory()
        {
            var serveyCategory = new List<ServeyCategory>();

            using (var httpClient = new HttpClient())
            {
                var tokenString = HttpContext.Request.Cookies.FirstOrDefault(c => c.Key == "TokenString").Value;

                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + tokenString);

                using (var response = await httpClient.GetAsync(APIEndPoint + "ServeyCategories"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        serveyCategory = JsonConvert.DeserializeObject<List<ServeyCategory>>(content);
                    }
                }
            }
            return serveyCategory;
        }

        // GET: Surveys/Create
        public async Task<IActionResult> Create()
        {
            ViewData["CategoryId"] = new SelectList(await this.GetServeyCategory(), "Id", "Name");
            return View();
        }

        // POST: Surveys/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Survey survey)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    using (var httpClient = new HttpClient())
                    {
                        var tokenString = HttpContext.Request.Cookies.FirstOrDefault(c => c.Key == "TokenString").Value;

                        httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + tokenString);

                        using (var response = await httpClient.PostAsJsonAsync(APIEndPoint + "Survey/", survey))
                        {
                            if (response.IsSuccessStatusCode)
                            {
                                var content = await response.Content.ReadAsStringAsync();
                                var result = JsonConvert.DeserializeObject<int>(content);

                                if (result > 0)
                                {
                                    return RedirectToAction(nameof(Index));
                                }
                            }
                        }
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
            }
            ViewData["CategoryId"] = new SelectList(await this.GetServeyCategory(), "Id", "Name", survey.CategoryId);

            return View(survey);
        }
    }
}

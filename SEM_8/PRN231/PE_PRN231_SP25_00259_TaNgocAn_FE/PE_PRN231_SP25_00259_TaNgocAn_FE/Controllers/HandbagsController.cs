using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PE_PRN231_SP25_00259_QE170035_Repository.Models;

namespace PE_PRN231_SP25_00259_TaNgocAn_FE.Controllers
{
    public class HandbagsController : Controller
    {
        private string APIEndPoint = "https://localhost:7122/api/";
        public HandbagsController() { }

        public async Task<IActionResult> Index()
        {
            using (var httpClient = new HttpClient())
            {
                #region Add Token to header of Request

                var tokenString = HttpContext.Request.Cookies.FirstOrDefault(c => c.Key == "TokenString").Value;

                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + tokenString);

                #endregion


                using (var response = await httpClient.GetAsync(APIEndPoint + "Handbag"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<List<Handbag>>(content);

                        if (result != null)
                        {
                            return View(result);
                        }
                    }
                }
            }
            return View(new List<Handbag>());
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
                using (var response = await httpClient.DeleteAsync(APIEndPoint + "Handbag/" + id))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        deleteStatus = true;
                    }
                }
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            using (var httpClient = new HttpClient())
            {
                var tokenString = HttpContext.Request.Cookies.FirstOrDefault(c => c.Key == "TokenString").Value;
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + tokenString);
                using (var response = await httpClient.GetAsync(APIEndPoint + "Handbag/" + id))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<Handbag>(content);

                        if (result != null) { return View(result); }
                    }
                    ModelState.AddModelError("", "Không thể tải dữ liệu. Vui lòng thử lại!");
                    return View("Error");
                }
            }
        }

        // GET: Surveys/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var brand = new List<Brand>();
            using (var httpClient = new HttpClient())
            {
                var tokenString = HttpContext.Request.Cookies.FirstOrDefault(c => c.Key == "TokenString").Value;
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + tokenString);
                using (var response = await httpClient.GetAsync(APIEndPoint + "Brand")) 
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        brand = JsonConvert.DeserializeObject<List<Brand>>(content);
                    }
                }
            }
            using (var httpClient = new HttpClient())
            {
                var tokenString = HttpContext.Request.Cookies.FirstOrDefault(c => c.Key == "TokenString").Value;
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + tokenString);
                using (var response = await httpClient.GetAsync(APIEndPoint + "Handbag/" + id)) 
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<Handbag>(content);
                        if (result != null)
                        {
                            ViewData["BrandId"] = new SelectList(brand, "BrandId", "BrandName", result.BrandId); 
                            return View(result);
                        }
                    }

                }
            }
            if (brand == null)
            {
                brand = new List<Brand>(); // Khởi tạo danh sách trống để tránh lỗi
            }
            ViewData["BrandId"] = new SelectList(brand, "BrandId", "BrandName");
            return View(new Handbag());
        }

        // POST: Surveys/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Handbag handbag)
        {
            var saveStatus = false;
            if (handbag == null)
            {
                // Xử lý nếu survey là null
                handbag = new Handbag();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    using (var httpClient = new HttpClient())
                    {
                        var tokenString = HttpContext.Request.Cookies.FirstOrDefault(c => c.Key == "TokenString").Value;
                        httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + tokenString);
                        using (var response = await httpClient.PutAsJsonAsync(APIEndPoint + "Handbag/" + handbag.HandbagId, handbag))
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
                if (handbag.BrandId == null)
                {
                    // Xử lý nếu survey là null
                    handbag = new Handbag();
                }
                var categories = await this.GetBrand();
                if (categories == null)
                {
                    // Xử lý trường hợp không có danh mục
                    categories = new List<Brand>();
                }
                ViewData["BrandId"] = new SelectList(categories, "BrandId", "BrandName", handbag.HandbagId);
                return View(handbag);
            }
        }

        //Get đối tượng phụ
        public async Task<List<Brand>> GetBrand()
        {
            var brand = new List<Brand>();
            using (var httpClient = new HttpClient())
            {
                var tokenString = HttpContext.Request.Cookies.FirstOrDefault(c => c.Key == "TokenString").Value;
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + tokenString);
                using (var response = await httpClient.GetAsync(APIEndPoint + "Brand"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        brand = JsonConvert.DeserializeObject<List<Brand>>(content);
                    }
                }
            }
            return brand;
        }

        // GET: Surveys/Create
        public async Task<IActionResult> Create()
        {
            ViewData["BrandId"] = new SelectList(await this.GetBrand(), "BrandId", "BrandName");
            return View();
        }

        // POST: Surveys/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Handbag handbag)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    using (var httpClient = new HttpClient())
                    {
                        var tokenString = HttpContext.Request.Cookies.FirstOrDefault(c => c.Key == "TokenString").Value;

                        httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + tokenString);

                        using (var response = await httpClient.PostAsJsonAsync(APIEndPoint + "Handbag/", handbag))
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
            ViewData["BrandId"] = new SelectList(await this.GetBrand(), "BrandId", "BrandName", handbag.BrandId);

            return View(handbag);
        }

        public async Task<IActionResult> Search(string? Color, string? ModelName, string? Material)
        {
            using (var httpClient = new HttpClient())
            {
                var tokenString = HttpContext.Request.Cookies.FirstOrDefault(c => c.Key == "TokenString").Value;
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + tokenString);

                string searchUrl = $"{APIEndPoint}Handbag/search?";
                if (!string.IsNullOrEmpty(Color)) searchUrl += $"CategoryName={Color}&";
                if (!string.IsNullOrEmpty(ModelName)) searchUrl += $"SkinType={ModelName}&";
                if (!string.IsNullOrEmpty(Material)) searchUrl += $"CosmeticSize={Material}&";

                using (var response = await httpClient.GetAsync(searchUrl.TrimEnd('&')))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<List<Handbag>>(content);
                        return View("Index", result);
                    }
                }
            }
            return View("Index", new List<Handbag>());
        }
    }
}

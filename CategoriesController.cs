using Calling_Web_API_Demo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

namespace Calling_Web_API_Demo.Controllers
{
    public class CategoriesController : Controller
    {

        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;
        private string baseApiUrl ="https://localhost:7141/api/Category";
        public CategoriesController(HttpClient client, IConfiguration config)
        {
            _httpClient=client;
            _config=config;
        }
        // GET: CategoriesController
        public async Task<IActionResult> Index()
        {
            var response=await _httpClient.GetAsync(baseApiUrl);
            var json=await response.Content.ReadAsStringAsync();
            var data = JsonSerializer.Deserialize<List<Category>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return View(data);
        }

        // GET: CategoriesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CategoriesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoriesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormCollection collection)
        {
            try
            {
                Category c=new Category();
                c.CategroyName = collection["CategroyName"].ToString();
                c.Description = collection["Description"].ToString();

                var json=JsonSerializer.Serialize(c);   
                var content=new StringContent(json,Encoding.UTF8,"application/json");
                var response=await _httpClient.PostAsync(baseApiUrl, content);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                return View(c);


                
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoriesController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var response = await _httpClient.GetAsync($"{baseApiUrl}/{id}");
            var json = await response.Content.ReadAsStringAsync();
            var data = JsonSerializer.Deserialize<Category>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return View(data);
        }

        // POST: CategoriesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, IFormCollection collection)
        {
            try
            {

                Category c = new Category();
                c.CategroyName = collection["CategroyName"].ToString();
                c.Description = collection["Description"].ToString();

                var json = JsonSerializer.Serialize(c);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _httpClient.PutAsync($"{baseApiUrl}/{id}", content);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                return View(c);


            }
            catch
            {
                return View();
            }
        }

        // GET: CategoriesController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _httpClient.GetAsync($"{baseApiUrl}/{id}");
            var json = await response.Content.ReadAsStringAsync();
            var data = JsonSerializer.Deserialize<Category>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return View(data);
        }

        // POST: CategoriesController/Delete/5
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                await _httpClient.DeleteAsync($"{baseApiUrl}/{id}");
                return RedirectToAction("Index");
                //Category c = new Category();
                //c.CategroyName = collection["CategroyName"].ToString();
                //c.Description = collection["Description"].ToString();

                //var json = JsonSerializer.Serialize(c);
                //var content = new StringContent(json, Encoding.UTF8, "application/json");
                //var response = await _httpClient.PutAsync($"{baseApiUrl}/{id}", content);
                //if (response.IsSuccessStatusCode)
                //{
                //    return RedirectToAction("Index");
                //}
                //return View(c);
            }
            catch
            {
                return View();
            }
        }
    }
}

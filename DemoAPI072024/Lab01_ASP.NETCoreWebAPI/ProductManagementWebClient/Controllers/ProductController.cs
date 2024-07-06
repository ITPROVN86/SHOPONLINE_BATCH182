using BusinessObjects;
using BusinessObjects.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Options;
using System.Net.Http.Headers;
using System.Text.Json;

namespace ProductManagementWebClient.Controllers
{
    public class ProductController : Controller
    {
        private readonly HttpClient _httpClient;
        private string ProductURL = "";
        private string CategoryURL = "";
        public ProductController()
        {
            _httpClient = new HttpClient();
            var content = new MediaTypeWithQualityHeaderValue("application/json");
            _httpClient.DefaultRequestHeaders.Accept.Add(content);
            ProductURL = "https://localhost:7167/api/Products";
            CategoryURL = "https://localhost:7167/api/Category";
        }
        // GET: ProductController
        public async Task<IActionResult> Index()
        {
            HttpResponseMessage res = await _httpClient.GetAsync(ProductURL);
            string rData = await res.Content.ReadAsStringAsync();
            var option = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            List<ProductDTO> list = JsonSerializer.Deserialize<List<ProductDTO>>(rData, option);
            return View(list);
        }

        // GET: ProductController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            HttpResponseMessage res = await _httpClient.GetAsync(ProductURL + "/" + id);
            string rData = await res.Content.ReadAsStringAsync();
            var option = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            Product product = JsonSerializer.Deserialize<Product>(rData, option);

            return View(product);
        }

        // GET: ProductController/Create
        public async Task<ActionResult> Create()
        {
            HttpResponseMessage res = await _httpClient.GetAsync(CategoryURL);
            string rData = await res.Content.ReadAsStringAsync();
            var option = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            List<Category> list = JsonSerializer.Deserialize<List<Category>>(rData, option);

            ViewData["CategoryId"] = new SelectList(list, "CategoryId", "CategoryName");
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Product p)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string strData = JsonSerializer.Serialize(p);
                    var contentData = new StringContent(strData, System.Text.Encoding.UTF8, "application/json");
                    HttpResponseMessage res = await _httpClient.PostAsync(ProductURL, contentData);
                    if (res.IsSuccessStatusCode)
                    {
                        ViewBag.Message = "Insert success!";
                    }
                    else
                    {
                        ViewBag.Message = "Insert fail!";
                    }

                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(p);
            }
        }

        // GET: ProductController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            HttpResponseMessage res = await _httpClient.GetAsync($"{ProductURL}/{id}");
            string rData = await res.Content.ReadAsStringAsync();
            var option = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            Product product = JsonSerializer.Deserialize<Product>(rData, option);

            HttpResponseMessage resCate = await _httpClient.GetAsync(CategoryURL);
            string rDataCate = await resCate.Content.ReadAsStringAsync();
            List<Category> list = JsonSerializer.Deserialize<List<Category>>(rDataCate, option);

            ViewData["CategoryId"] = new SelectList(list, "CategoryId", "CategoryName",product.CategoryId);
            return View(product);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Product p)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string strData = JsonSerializer.Serialize(p);
                    var contentData = new StringContent(strData, System.Text.Encoding.UTF8, "application/json");
                    HttpResponseMessage res = await _httpClient.PutAsync($"{ProductURL}/{id}", contentData);
                    if (res.IsSuccessStatusCode)
                    {
                        ViewBag.Message = "Insert success!";
                    }
                    else
                    {
                        ViewBag.Message = "Insert fail!";
                    }

                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                HttpResponseMessage resCate = await _httpClient.GetAsync(CategoryURL);
                string rDataCate = await resCate.Content.ReadAsStringAsync();
                var option = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                List<Category> list = JsonSerializer.Deserialize<List<Category>>(rDataCate, option);

                ViewData["CategoryId"] = new SelectList(list, "CategoryId", "CategoryName", p.CategoryId);
                return View(p);
            }
        }

        // GET: ProductController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            HttpResponseMessage res = await _httpClient.GetAsync(ProductURL + "/" + id);
            string rData = await res.Content.ReadAsStringAsync();
            var option = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            Product product = JsonSerializer.Deserialize<Product>(rData, option);

            return View(product);
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, Product p)
        {
            try
            {
                HttpResponseMessage res = await _httpClient.DeleteAsync($"{ProductURL}/{id}");
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(p);
            }
        }
    }
}

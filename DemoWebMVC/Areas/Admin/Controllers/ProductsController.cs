using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ShopBusiness.Models;
using ShopRepository;
using X.PagedList;


namespace DemoWebMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    [Authorize(AuthenticationSchemes = "Admin")]
    public class ProductsController : BaseController
    {
        private readonly IProductRepository productRepository;
        private readonly ICategoryRepository categoryRepository;
        private readonly IUserRepository userRepository;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IMapper mapper;

        public ProductsController(IWebHostEnvironment webHostEnvironment, IMapper mapper)
        {
            productRepository = new ProductRepository();
            categoryRepository = new CategoryRepository();
            userRepository = new UserRepository();
            mapper = mapper;
            this.webHostEnvironment = webHostEnvironment;
        }

        // GET: Admin/Products
        public async Task<IActionResult> Index(string searchString, int? page, int categoryId)
        {
            var product = await productRepository.GetAllProduct();
            if (!string.IsNullOrEmpty(searchString))
            {
                product = product.Where(c => ShopCommon.Library.ConvertToUnSign(c.ProductName.ToLower()).Contains(ShopCommon.Library.ConvertToUnSign(searchString.ToLower())));
            }
            if (categoryId != 0)
            {
                product = product.Where(u => u.CategoryId == categoryId);
            }
            ViewData["CategoryId"] = new SelectList(await categoryRepository.GetAllCategory(), "CategoryId", "CategoryName");
            ViewBag.Page = 5;
            return View(product.ToPagedList(page ?? 1, (int)ViewBag.Page));
        }

        // GET: Admin/Products/Create
        public async Task<IActionResult> Create()
        {
            var model = new Product
            {
                CreatePost = ShopCommon.Library.GetServerDateTime()  // Đặt ngày mặc định ngay trước khi gửi đến view
            };
            ViewData["CategoryId"] = new SelectList(await categoryRepository.GetAllCategory(), "CategoryId", "CategoryName");
            ViewData["UserPost"] = new SelectList(await userRepository.GetAllUser(), "UserId", "FullName");
            return View(model);
        }

        // POST: Admin/Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,ProductName,Description,Ncontent,CategoryId,ImageUrl, ImageFile, Price,CreatePost,UserPost,Status")] Product product)
        {

            ViewData["CategoryId"] = new SelectList(await categoryRepository.GetAllCategory(), "CategoryId", "CategoryName");
            ViewData["UserPost"] = new SelectList(await userRepository.GetAllUser(), "UserId", "FullName");
            if (ModelState.IsValid)
            {
                if (product.ImageFile != null)
                {
                    string uniqueFileName = UploadedFile(product);
                    product.ImageUrl = uniqueFileName;
                }
                await productRepository.Add(product);
                SetAlert(ShopCommon.Contants.UPDATE_SUCCESS, ShopCommon.Contants.SUCCESS);
                return RedirectToAction(nameof(Index));
            }

            return View(product);
        }

        // GET: Admin/Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var product = await productRepository.GetProductById(Convert.ToInt32(id));
            if (product == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(await categoryRepository.GetAllCategory(), "CategoryId", "CategoryName", product.CategoryId);
            ViewData["UserPost"] = new SelectList(await userRepository.GetAllUser(), "UserId", "FullName", product.UserPost);
            return View(product);
        }

        // POST: Admin/Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,ProductName,Description,Ncontent,CategoryId,ImageUrl, ImageFile, Price,CreatePost,UserPost,Status")] Product product)
        {
            if (ModelState.IsValid)
            {
                if (product.ImageFile != null)
                {
                    string uniqueFileName = UploadedFile(product);
                    product.ImageUrl = uniqueFileName;
                }
                /* else
                 {
                     var productFind = await productRepository.GetProductById(product.ProductId);
                     product.ImageUrl = productFind.ImageUrl;
                 }*/
                await productRepository.Update(product);
                SetAlert(ShopCommon.Contants.UPDATE_SUCCESS, ShopCommon.Contants.SUCCESS);
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(await categoryRepository.GetAllCategory(), "CategoryId", "CategoryName", product.CategoryId);
            ViewData["UserPost"] = new SelectList(await userRepository.GetAllUser(), "UserId", "FullName", product.UserPost);
            return View(product);
        }

        [HttpPost]
        public async Task<JsonResult> DeleteId(int id)
        {
            try
            {
                var category = await productRepository.GetProductById(id);
                if (category == null)
                {
                    return Json(new { success = false, message = "Không tìm thấy bản ghi" });
                }
                await productRepository.Delete(id);
                SetAlert(ShopCommon.Contants.DELETE_SUCCESS, ShopCommon.Contants.SUCCESS);
                return Json(new
                {
                    status = true
                });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<JsonResult> ChangeStatus(int id)
        {
            var result = await productRepository.ChangeStatus(id);
            return Json(new
            {
                status = result
            });
        }

        public string UploadedFile(Product product)
        {
            //string uniqueFileName = UploadedFile(hh);
            //Save image to wwwroot/image
            string wwwRootPath = this.webHostEnvironment.WebRootPath;
            var exe = product.ImageFile.FileName;
            string fileName = Path.GetFileNameWithoutExtension(exe);
            string extension = Path.GetExtension(product.ImageFile.FileName);
            product.ImageUrl = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            string path = Path.Combine(wwwRootPath + "/Upload/Images/", fileName);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                product.ImageFile.CopyTo(fileStream);
            }
            ViewBag.Anh = product.ImageUrl;
            return fileName;
        }

        [HttpPost]
        public async Task<IActionResult> UploadImage(IFormFile upload)
        {
            if (upload != null && upload.Length > 0)
            {
                // Get the current date and format it
                var currentDate = DateTime.Now;
                var year = currentDate.Year.ToString();
                var month = currentDate.Month.ToString().PadLeft(2, '0');
                var day = currentDate.Day.ToString().PadLeft(2, '0');

                // Create the directory string and ensure the directory exists
                var directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/upload/images", year, month);
                Directory.CreateDirectory(directoryPath); // Creates all directories on the path if not exist

                // Modify the filename to include the date
                var fileName = $"{year}{month}{day}_{Path.GetFileName(upload.FileName)}";
                var filePath = Path.Combine(directoryPath, fileName);

                // Save the file
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await upload.CopyToAsync(stream);
                }

                // Return the JSON result with the URL to the uploaded file
                return Json(new { uploaded = true, url = $"/upload/images/{year}/{month}/{fileName}" });
            }

            return Json(new { uploaded = false, message = "Upload failed" });
        }


    }
}

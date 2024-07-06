using BusinessObjects;
using Microsoft.AspNetCore.Mvc;
using Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _repository;
        public CategoryController()
        {
            _repository = new CategoryRepository();
        }
        // GET: api/<ProductsController>
        [HttpGet]
        public ActionResult<IEnumerable<Category>> GetCategories()=> _repository.GetCategories();
        
        [HttpGet("{id}")]
        public ActionResult<Category> GetCategory(int id) => _repository.GetCategoryById(id);

        // POST api/<ProductsController>
        [HttpPost]
        public IActionResult PostCategory(Category c)
        {
            _repository.Add(c);
            return Content("Insert success!");
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public IActionResult PutCategory(int id, Category c)
        {
            var tmp = _repository.GetCategoryById(id);
            if (tmp == null)
            {
                return NotFound();
            }
            _repository.Update(c);
            return NoContent();
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var tmp = _repository.GetCategoryById(id);
            if (tmp == null)
            {
                return NotFound();
            }
            _repository.Delete(tmp);
            return NoContent();
        }
    }
}

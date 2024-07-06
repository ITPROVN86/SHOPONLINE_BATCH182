using AutoMapper;
using BusinessObjects;
using BusinessObjects.DTO;
using Microsoft.AspNetCore.Mvc;
using Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;
        public ProductsController(IMapper mapper)
        {
            _repository = new ProductRepository();
            _mapper = mapper;
        }
        // GET: api/<ProductsController>
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            var products = _repository.GetProducts();
            var productDTO = _mapper.Map<IEnumerable<ProductDTO>>(products);
            return Ok(productDTO);
        }
        
        [HttpGet("{id}")]
        public ActionResult<Product> GetProducts(int id) => _repository.GetProductById(id);

        // POST api/<ProductsController>
        [HttpPost]
        public IActionResult PostProduct(Product p)
        {
            _repository.Add(p);
            return Content("Insert success!");
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public IActionResult PutProduct(int id, Product p)
        {
            var tmp = _repository.GetProductById(id);
            if (tmp == null)
            {
                return NotFound();
            }
            _repository.Update(p);
            return NoContent();
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var tmp = _repository.GetProductById(id);
            if (tmp == null)
            {
                return NotFound();
            }
            _repository.Delete(tmp);
            return NoContent();
        }
    }
}

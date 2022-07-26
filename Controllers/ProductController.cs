using Day1Lab.Models;
using Day1Lab.Models.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Day1Lab.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository productRepo;

        public ProductController(IProductRepository productRepo)
        {
            this.productRepo = productRepo;
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, Product prod)
        {
            var product = productRepo.GetById(id);
            productRepo.Update(product);
            return Ok(product);
        }

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var products = productRepo.GetAll();
            return Ok(products);
        }

        [HttpGet("{id:int}", Name = "ProductDetailsRoute")]
        public IActionResult GetProductById(int id)
        {
            var product = productRepo.GetById(id);
            if(product != null)
            {
                return Ok(product);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("{name:alpha}")]
        public IActionResult GetProductByName(string name)
        {
            var product = productRepo.GetByName(name);
            return Ok(product);
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            string? url = Url.Link("ProductDetailsRoute", new { id = product.Id });
            if (ModelState.IsValid)
            {
                productRepo.Add(product);
                return Created(url, product);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete("{id:int}")]
        public IActionResult RemoveProduct(int id)
        {
            if(id != null || id != 0)
            {
                productRepo.Delete(id);
                return StatusCode(StatusCodes.Status200OK);
            }
            else
            {
                return NotFound();
            }
        }
    }
}

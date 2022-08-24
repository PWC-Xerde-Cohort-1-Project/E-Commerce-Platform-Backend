using eCommerce.Data;
using eCommerce.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductDbContext _context;
        public ProductController(ProductDbContext context)
        {
            _context = context;
        }

        [HttpGet("GetProduct")]
        public IActionResult Get()
        {
            var products = _context.Products.ToList();
            if (products.Count == 0)
            {
                return BadRequest("No product");
            }
            return Ok(products);
        }

        [HttpPost("CreateProduct")]
        public async Task<IActionResult> Create(ProductRequest request)
        {
            if (_context.Products.Any(u => u.Name == request.Name))
            {
                return BadRequest("Product already exist");
            }
            var product = new Product
            {
                Name = request.Name,
                Price = request.Price, 
                Description = request.Description,
                Image  = request.Image,
                Rate = request.Rate, 
                Count = request.Count,
                CategoryId = request.CategoryId
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return Ok("Product successfully created");
        }

        [HttpDelete("DeleteProduct")]
        public async Task<IActionResult> Delete(CategoryRequest request)
        {
            try
            {
                var product = _context.Products.FirstOrDefault(x => x.Id == request.Id);
                if (product == null)
                {
                    return StatusCode(404);
                }

                _context.Entry(product).State = EntityState.Deleted;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }

            var categories = _context.Products.ToList();
            return Ok("product deleted");
        }
    }
}

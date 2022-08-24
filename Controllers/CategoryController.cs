using eCommerce.Data;
using eCommerce.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryDbContext _context;
        public CategoryController(CategoryDbContext context)
        {
            _context = context;
        }

        [HttpGet ("GetCategory")]
        public IActionResult Get()
        {
            var categories = _context.Categories.ToList();


            if (categories.Count == 0)
            {
                return BadRequest("No category");
            }
            return Ok(categories);
        }

        [HttpPost("CreateCategory")]
        public async Task<IActionResult> Create(CategoryRequest request)
        {
            if (_context.Categories.Any(u => u.Name == request.Name))
            {
                return BadRequest("Category already exist");
            }
            var category = new Category
            {
                Name = request.Name,
               Slug = request.Slug
            };

            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return Ok("Category successfully updated");
        }

        [HttpPut("UpdateCategory")]
        public async Task<IActionResult> Update (CategoryRequest request)
        {
            try
            {
                var category = _context.Categories.FirstOrDefault(x => x.Id == request.Id);
                if (category == null)
                {
                    return StatusCode(404);
                }

                category.Name = request.Name;
                category.Slug = request.Slug;

                _context.Entry(category).State = EntityState.Modified;
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
            var categories = _context.Categories.ToList();
            return Ok("categories updated");
            //var check = _context.Categories.Any(u => u.Id == request.Id);
            //if (check == null)
            //{
            //    return BadRequest("Category does not exist");
            //}
            //var category = new Category
            //{
            //    Name = request.Name,
            //    Slug = request.Slug
            //};

            //_context.Categories.Update(category);
            //await _context.SaveChangesAsync();
            //return Ok("Category successfully created");
        }

        [HttpDelete("DeleteCategory")]
        public async Task<IActionResult> Delete(CategoryRequest request)
        {
            try
            {
                var category = _context.Categories.FirstOrDefault(x => x.Id == request.Id);
                if (category == null)
                {
                    return StatusCode(404);
                }

                _context.Entry(category).State = EntityState.Deleted;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }

            var categories = _context.Categories.ToList();
            return Ok("Categories deleted");
        }

        //[HttpDelete("DeleteCategory/{Id}")]
        //public async IActionResult Delete(CategoryRequest request int Id)
        //{

        //}
    }
}

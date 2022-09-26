using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        ICategoryService _ıcategoryService;
        public CategoryController(ICategoryService ıcategoryService)
        {
            _ıcategoryService = ıcategoryService;
        }

        [HttpPost("Added")]
        public IActionResult Added(Category category)
        {
            var result = _ıcategoryService.Add(category);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Remove")]
        public IActionResult Delete(Category category)
        {
            var result = _ıcategoryService.Delete(category);

            if (result.Success)
            {
                return Ok(result.Success);
            }
            return BadRequest(result);
        }


        [HttpGet("Listed")]

        public IActionResult GetAll()
        {
            var result = _ıcategoryService.GetList();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost("Updated")]
        public IActionResult Updated(Category category)
        {
            var result = _ıcategoryService.Update(category);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    
    }
}

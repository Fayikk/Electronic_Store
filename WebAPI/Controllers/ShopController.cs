using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        IShopService _ıshopService;
        public ShopController(IShopService shopService)
        {
            _ıshopService = shopService;
        }

        [HttpPost("Add")]
        public IActionResult Add(Shop shop)
        {
            var result = _ıshopService.Add(shop);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Remove")]
        public IActionResult Deleted(Shop shop)
        {
            var result = _ıshopService.Delete(shop);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest();
        }


        [HttpGet("lİSTEDdB")]
        public IActionResult GetAll()
        {
            var result = _ıshopService.GetList();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}

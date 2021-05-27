using Microsoft.AspNetCore.Mvc;
using Entities.Concrete;
using Business.Abstract;


namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private IBrandService _brandService;

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet("getall")]
        public  IActionResult GetAll()
        {
           var result= _brandService.GetAll();
           if (result.Success)
           {
               return Ok(result);
           }

           return BadRequest(result);
        }
    }
}

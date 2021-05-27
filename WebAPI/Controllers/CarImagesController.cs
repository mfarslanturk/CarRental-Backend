using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        ICarImageService _carImageService;

        public CarImagesController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carImageService.GetAll();

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("getallimageforcarid")]
        public IActionResult GetAllImageForCarId(int carId)
        {
            var result = _carImageService.GetAllImageForCarId(carId);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm] CarImage carImage)
        {
            var result = _carImageService.Add(carImage);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("update")]
        public IActionResult Update([FromForm] CarImage carImage)
        {
            var result = _carImageService.Update(carImage);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete([FromForm] CarImage carImage)
        {
            var result = _carImageService.Delete(carImage);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

    }
}

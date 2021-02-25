using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        ICarImagesService _carImagesService;
        public CarImagesController(ICarImagesService carImagesService)
        {
            _carImagesService = carImagesService;
        }

        [HttpPost("add")]
        public IActionResult Add(CarImages carImages)
        {
            var result = _carImagesService.Add(carImages);
            if (result.Success)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPost("delete")]
        public IActionResult Delete(CarImages carImages)
        {
            var result = _carImagesService.Delete(carImages);
            if (result.Success)
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpPost("update")]
        public IActionResult Update(CarImages carImages)
        {
            var result = _carImagesService.Update(carImages);
            if (result.Success)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carImagesService.GetAll();
            if (result.Success)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}

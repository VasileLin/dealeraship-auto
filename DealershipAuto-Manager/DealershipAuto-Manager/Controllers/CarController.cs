using DealershipAuto_Manager.Dtos;
using DealershipAuto_Manager.Models;
using DealershipAuto_Manager.Services;
using Microsoft.AspNetCore.Mvc;

namespace DealershipAuto_Manager.Controllers
{
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpPost]
        [Route("cars")]
        [ActionName("Add a car")]
        public IActionResult Add(AddCarDto car)
        {
            _carService.Add(car);
            return Ok();
        }

        [HttpGet]
        [Route("cars")]
        public IActionResult GetAll()
        {
           var result = _carService.GetAll();
            return Ok(result);
        }

        [HttpGet]
        [Route("cars/{carId}")]
        public IActionResult GetById(Guid carId) 
        {
            var result = _carService.Get(carId);

            return result is null ? NotFound() : Ok(result);
        }

        [HttpPut]
        [Route("cars/{carId}")]
        public IActionResult Update(Guid carId,UpdateCarDto car)
        {
            _carService.Update(carId,car);
            return Ok();
        }

        [HttpDelete]
        [Route("cars/{carId}")]
        public IActionResult Delete(Guid carId)
        {
            _carService.Delete(carId);
            return NoContent();
        }
    }
}

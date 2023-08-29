using DealershipAuto_Manager.Dtos;
using DealershipAuto_Manager.Services;
using Microsoft.AspNetCore.Mvc;

namespace DealershipAuto_Manager.Controllers
{
    [ApiController]
    public class SaleController :ControllerBase
    {
        private readonly ISaleService _saleService;

        public SaleController(ISaleService saleService)
        {
            _saleService = saleService;
        }

        [HttpPost]
        [Route("sales")]
        public IActionResult Add(AddSaleDto saleDto)
        {
            _saleService.Add(saleDto);
            return Ok();
        }

        [HttpGet]
        [Route("sales")]
        public IActionResult GetAll()
        {
            var result = _saleService.GetAll();
            return Ok(result);
        }

        [HttpDelete]
        [Route("sales/{saleId}")]
        public IActionResult Delete(Guid saleId)
        {
            _saleService.Delete(saleId);
            return NoContent();
        }
    }
}

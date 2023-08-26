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
    }
}

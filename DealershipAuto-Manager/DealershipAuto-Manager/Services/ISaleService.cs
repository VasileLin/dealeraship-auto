using DealershipAuto_Manager.Dtos;
using DealershipAuto_Manager.Models;

namespace DealershipAuto_Manager.Services
{
    public interface ISaleService
    {
        void Add(AddSaleDto saleDto);
        List<Sale> GetAll();
    }
}

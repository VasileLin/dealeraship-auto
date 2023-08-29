using DealershipAuto_Manager.Models;

namespace DealershipAuto_Manager.Repositories
{
    public interface ISaleRepository
    {
        void Add(Sale sale);
        void Delete(Guid saleId);
        List<Sale> GetAll();
    }
}

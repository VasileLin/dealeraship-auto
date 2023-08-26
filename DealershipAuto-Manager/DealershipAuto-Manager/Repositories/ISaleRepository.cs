using DealershipAuto_Manager.Models;

namespace DealershipAuto_Manager.Repositories
{
    public interface ISaleRepository
    {
        void Add(Sale sale);
        List<Sale> GetAll();
    }
}

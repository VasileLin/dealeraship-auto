using DealershipAuto_Manager.Models;

namespace DealershipAuto_Manager.Repositories
{
    public class InMemorySaleRepository : ISaleRepository
    {
        private readonly static List<Sale> _sales = new List<Sale>();
        public void Add(Sale sale)
        {
            _sales.Add(sale);
        }

        public List<Sale> GetAll()
        {
            return _sales;
        }
    }
}

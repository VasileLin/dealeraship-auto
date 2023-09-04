using DealershipAuto_Manager.Data;
using DealershipAuto_Manager.Models;
using Microsoft.EntityFrameworkCore;

namespace DealershipAuto_Manager.Repositories
{
    public class SaleRepository : ISaleRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public SaleRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(Sale sale)
        {
            _dbContext.Sales.Add(sale);
            _dbContext.SaveChanges();
        }

        public void Delete(Guid saleId)
        {
            var saleToDelete = _dbContext.Sales.FirstOrDefault(q => q.Id == saleId);

            if (saleToDelete != null)
            {
                _dbContext.Sales.Remove(saleToDelete);
                _dbContext.SaveChanges();
            }
        }

        public List<Sale> GetAll()
        {
            return _dbContext.Sales
                .Include(c => c.Car)
                .Include(c => c.Client)
                .ToList();

        }
    }
}

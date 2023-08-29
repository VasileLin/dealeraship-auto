using DealershipAuto_Manager.Data;
using DealershipAuto_Manager.Models;

namespace DealershipAuto_Manager.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CarRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(Car car)
        {
            _dbContext.Add(car);
            _dbContext.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var carToDelete = _dbContext.Cars.FirstOrDefault(q => q.Id == id);

            if (carToDelete != null)
            {
                _dbContext.Cars.Remove(carToDelete);
                _dbContext.SaveChanges();
            }
        }

        public Car? Get(Guid id)
        {
            return _dbContext.Cars.FirstOrDefault(q => q.Id == id);
        }

        public List<Car> GetAll()
        {
            return _dbContext.Cars.ToList();
        }

        public void Update(Car car)
        {
            var carToUpdate = _dbContext.Cars.FirstOrDefault(q => q.Id == car.Id);

            if (carToUpdate != null)
            {
                carToUpdate.Brand = car.Brand;
                carToUpdate.Model = car.Model;
                carToUpdate.Category = car.Category;
                carToUpdate.Price = car.Price;
                carToUpdate.ProductionYear = car.ProductionYear;
                _dbContext.SaveChanges();
            }
        }
    }
}

using DealershipAuto_Manager.Models;

namespace DealershipAuto_Manager.Repositories
{
    public interface ICarRepository
    {
        void Add(Car car);
        Car? Get(Guid id);
        List<Car> GetAll();
        void Update(Car car);
        void Delete(Guid id);
        List<Car> GetByFilter(string model, string brand, int productionYear);
    }
}

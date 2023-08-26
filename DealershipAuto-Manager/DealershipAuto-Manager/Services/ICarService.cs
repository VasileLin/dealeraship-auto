using DealershipAuto_Manager.Dtos;
using DealershipAuto_Manager.Models;
using System.Security.Cryptography;

namespace DealershipAuto_Manager.Services
{
    public interface ICarService
    {
        void Add(AddCarDto carDto);
        Car? Get(Guid id);
        List<Car> GetAll();
        void Update(Guid carId,UpdateCarDto carDto);
        void Delete(Guid id);
    }
}

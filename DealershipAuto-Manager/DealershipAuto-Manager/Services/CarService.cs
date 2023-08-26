using DealershipAuto_Manager.Dtos;
using DealershipAuto_Manager.Models;
using DealershipAuto_Manager.Repositories;

namespace DealershipAuto_Manager.Services
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;
        private readonly ICarValidator _carValidator;

        public CarService(ICarRepository carRepository, ICarValidator carValidator)
        {
            _carRepository = carRepository;
            _carValidator = carValidator;
        }
        public void Add(AddCarDto carDto)
        {
            var isValid = _carValidator.IsValidAddCarDto(carDto);
            if (!isValid)
            {
                throw new ArgumentException("Invalid Car info. Could not add the car");
            }
            var car = new Car
            {
                Id = Guid.NewGuid(),
                Brand =carDto.Brand,
                Category = carDto.Category,
                Model = carDto.Model,
                Price =carDto.Price,
                ProductionYear = carDto.ProductionYear,
                IsSold = false
            };
            _carRepository.Add(car);
        }

        public void Delete(Guid id)
        {
            _carRepository.Delete(id);
        }

        public Car? Get(Guid id)
        {
           return _carRepository.Get(id);
        }

        public List<Car> GetAll()
        {
           return _carRepository.GetAll();
        }

        public void Update(Guid carId,UpdateCarDto carDto)
        {
            var isValid = _carValidator.IsValidUpdateCarDto(carDto);
            if (!isValid)
            {
                throw new ArgumentException("Invalid Car info. Could not add the car");
            }

            var car = new Car
            {
                Id = carId,
                Brand = carDto.Brand,
                Category = carDto.Category,
                Model = carDto.Model,
                Price = carDto.Price,
                ProductionYear = carDto.ProductionYear,
            };

            _carRepository.Update(car);
        }


        
    }
}

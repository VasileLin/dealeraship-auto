using DealershipAuto_Manager.Dtos;
using DealershipAuto_Manager.Models;
using DealershipAuto_Manager.Repositories;

namespace DealershipAuto_Manager.Services
{
    public class SaleService : ISaleService
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IClientRepository _clientRepository;
        private readonly ICarRepository _carRepository;

        public SaleService(ISaleRepository saleRepository, IClientRepository clientRepository, ICarRepository carRepository)
        {
            _saleRepository = saleRepository;
            _clientRepository = clientRepository;
            _carRepository = carRepository;
        }

        public void Add(AddSaleDto saleDto)
        {
            var car = _carRepository.Get(saleDto.CarId);
            var isValidCar = IsValidCar(car);

            var client = _clientRepository.Get(saleDto.ClientId);
            var isValidClient = IsValidClient(client);

            if (!isValidCar || !isValidClient || saleDto.FinalPrice < 0)
            {
                throw new ArgumentException("Invalid sale data. Could not register the sale.");
            }

            var sale = new Sale
            {
                Id = Guid.NewGuid(),
                Date = DateTime.UtcNow,
                CarId = car.Id,
                Car = car,
                Client = client,
                ClientId = client.Id,
                FinalPrice = saleDto.FinalPrice,
            };

            _saleRepository.Add(sale);

            car.IsSold = true;

            _carRepository.Update(car);
        }

        public void Delete(Guid saleId)
        {
            _saleRepository.Delete(saleId);
        }

        public List<Sale> GetAll()
        {
            return _saleRepository.GetAll();
        }

        private bool IsValidCar(Car? car)
        {
            if (car is null) { return false; }
            if (car.IsSold) { return false; }
            return true;
        }

        private bool IsValidClient(Client? client)
        {
            if (client is null)
            {
                return false;
            }
            return true;
        }
    }
}

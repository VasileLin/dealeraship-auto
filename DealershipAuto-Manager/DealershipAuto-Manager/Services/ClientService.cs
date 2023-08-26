using DealershipAuto_Manager.Dtos;
using DealershipAuto_Manager.Models;
using DealershipAuto_Manager.Repositories;

namespace DealershipAuto_Manager.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IClientValidator _clientValidator;

        public ClientService(IClientRepository clientRepository, IClientValidator clientValidator)
        {
            _clientRepository = clientRepository;
            _clientValidator = clientValidator;
        }
        public void Add(AddClientDto clientDto)
        {
            var isValid = _clientValidator.IsValidAddClientDto(clientDto);
            if (!isValid)
            {
                throw new ArgumentException("Invalid client info. Could not add client.");
            }

            var client = new Client
            {
                Id = Guid.NewGuid(),
                Name = clientDto.Name,
                IsCompany = clientDto.IsCompany
            };

            _clientRepository.Add(client);
        }

        public void Delete(Guid id)
        {
            _clientRepository.Delete(id);
        }

        public Client? Get(Guid id)
        {
            return _clientRepository.Get(id);
        }

        public List<Client> GetAll()
        {
            return _clientRepository.GetAll();
        }

        public void Update(Guid clientId,UpdateClientDto clientDto)
        {
            var client = new Client
            {
                Id = clientId,
                Name = clientDto.Name,
                IsCompany = clientDto.IsCompany
            };
            _clientRepository.Update(client);
        }
    }
}

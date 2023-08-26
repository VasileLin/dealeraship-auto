using DealershipAuto_Manager.Dtos;
using DealershipAuto_Manager.Models;

namespace DealershipAuto_Manager.Services
{
    public interface IClientService
    {
        void Add(AddClientDto clientDto);
        Client? Get(Guid id);
        List<Client> GetAll();
        void Update(Guid clientId, UpdateClientDto clientDto);
        void Delete(Guid id);
    }
}

using DealershipAuto_Manager.Models;

namespace DealershipAuto_Manager.Repositories
{
    public class InMemoryClientRepository : IClientRepository
    {
        private static readonly List<Client> _clients = new List<Client>();

        public void Add(Client client)
        {
            _clients.Add(client);
        }

        public void Delete(Guid id)
        {
            var result = _clients.FirstOrDefault(q => q.Id == id);

            if (result != null) {
                _clients.Remove(result);
            }
        }

        public Client? Get(Guid id)
        {
            return _clients.FirstOrDefault(q => q.Id == id);
        }

        public List<Client> GetAll()
        {
            return _clients;
        }

        public void Update(Guid clientId, Client client)
        {
            var clientToUpdate = _clients.FirstOrDefault(q => q.Id == clientId);

            if (clientToUpdate != null)
            {
                clientToUpdate.Name = client.Name;
                clientToUpdate.IsCompany = client.IsCompany;
            }
        }
    }
}

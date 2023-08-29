using DealershipAuto_Manager.Data;
using DealershipAuto_Manager.Models;

namespace DealershipAuto_Manager.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ClientRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Client client)
        {
            _dbContext.Clients.Add(client);
            _dbContext.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var result = _dbContext.Clients.FirstOrDefault(q => q.Id == id);

            if (result != null)
            {
                _dbContext.Clients.Remove(result);
                _dbContext.SaveChanges();
            }
        }

        public Client? Get(Guid id)
        {
            return _dbContext.Clients.FirstOrDefault(q => q.Id == id);
        }

        public List<Client> GetAll()
        {
            return _dbContext.Clients.ToList();
        }

        public void Update(Client client)
        {
            var clientUpdate = _dbContext.Clients.FirstOrDefault(q => q.Id == client.Id);

            if (clientUpdate != null)
            {
                clientUpdate.Name = client.Name;
                clientUpdate.IsCompany = client.IsCompany;

                _dbContext.SaveChanges();
            }
        }
    }
}

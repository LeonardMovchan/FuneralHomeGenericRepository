using FuneralHome.Data.Entities;
using FuneralHome.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace FuneralHome.Data.Repositories
{
    public class ClientRepository : GenericRepository<Client>, IClientRepository
    {
        private readonly FuneralHomeContext _ctx;       
        public ClientRepository(FuneralHomeContext context) : base(context)
        {
            _ctx = context;
        }

        public IEnumerable<Client> GetAllClients()
        {
            return _ctx.Clients
                .Include(x => x.Funerals.Select(y => y.DateUtc)).ToList();
        }

    }
}

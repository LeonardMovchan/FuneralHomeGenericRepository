using FuneralHome.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuneralHome.Domain.Interfaces
{
    public interface IClientService
    {
        ClientModel Create(ClientModel model);
        ClientModel Update(ClientModel model);
        IEnumerable<ClientModel> GetAll();

    }
}

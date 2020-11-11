using AutoMapper;
using FuneralHome.Domain.Interfaces;
using FuneralHome.Domain.Models;
using FuneralHome.Domain.Services;
using FuneralHome.Models.PostModels;
using FuneralHome.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuneralHome.Controllers
{
    public class ClientControllers
    {

        private readonly IClientService _clientService;
        private readonly IMapper _mapper;

        public ClientControllers()
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ClientPostModel, ClientModel>().ReverseMap();
                cfg.CreateMap<ClientViewModel, ClientModel>().ReverseMap();

            });

            _mapper = new Mapper(mapperConfig);

            _clientService = new ClientService();

        }

        public ClientViewModel Update(ClientViewModel model)
        {
            var clientMapper = _mapper.Map<ClientModel>(model);
            var updatedClient = _clientService.Update(clientMapper);

            return _mapper.Map<ClientViewModel>(updatedClient);
        }

        public ClientViewModel Create(ClientPostModel model)
        {
            var clientMapper = _mapper.Map<ClientModel>(model);
            var updatedClient = _clientService.Create(clientMapper);

            return _mapper.Map<ClientViewModel>(updatedClient);
        }

        public IEnumerable<ClientViewModel> GetAll()
        {
            IEnumerable<ClientModel> models = _clientService.GetAll();

            return _mapper.Map<IEnumerable<ClientViewModel>>(models);
        }
    }

}

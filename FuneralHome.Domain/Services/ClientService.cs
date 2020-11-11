using AutoMapper;
using FuneralHome.Data;
using FuneralHome.Data.Entities;
using FuneralHome.Data.Repositories;
using FuneralHome.Domain.Interfaces;
using FuneralHome.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FuneralHome.Domain.Services
{
    public class ClientService : IClientService
    {
        private readonly IMapper _mapper;
        private readonly ClientRepository _clientRepository;

        public ClientService()
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Client, ClientModel>().ReverseMap();
            });

            _mapper = new Mapper(mapperConfig);
            _clientRepository = new ClientRepository(new FuneralHomeContext());
        }

        public ClientModel Create(ClientModel model)
        {
            var clientMapper = _mapper.Map<Client>(model);
            var createdFuneral = _clientRepository.Create(clientMapper);

            return _mapper.Map<ClientModel>(createdFuneral);

        }

        public IEnumerable<ClientModel> GetAll()
        {
            IEnumerable<Client> models = _clientRepository.GetAll();

            var mappedModels = _mapper.Map<IEnumerable<ClientModel>>(models);

            return mappedModels;
        }

        public ClientModel Update(ClientModel model)
        {
            var clientMapper = _mapper.Map<Client>(model);
            var updatedClient = _clientRepository.Update(clientMapper);

            return _mapper.Map<ClientModel>(updatedClient);
        }
    }

}

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
    public class FuneralsControllers
    {
        private readonly IFuneralService _funeralService;
        private readonly IMapper _mapper;

        public FuneralsControllers()
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<FuneralModel, FuneralViewModel>().ReverseMap();
                cfg.CreateMap<ClientModel, ClientViewModel>().ReverseMap();
                cfg.CreateMap<EmployeeModel, EmployeeViewModel>().ReverseMap();
                cfg.CreateMap<FuneralPostModel, FuneralModel>().ReverseMap();
                
                
                
            });
            
            _mapper = new Mapper(mapperConfig);

            _funeralService = new FuneralService();
          
        }

        public IEnumerable<FuneralViewModel> GetAll()
        {
            var model = _funeralService.GetAll();

            return _mapper.Map<IEnumerable<FuneralViewModel>>(model);
        }

        public FuneralViewModel Create(FuneralPostModel model)
        {
            var funeralModel = _mapper.Map<FuneralModel>(model);

            var createdModel = _funeralService.Create(funeralModel);
            return _mapper.Map<FuneralViewModel>(createdModel);
        }
    }

}

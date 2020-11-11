using AutoMapper;
using FuneralHome.Data.Entities;
using FuneralHome.Data.Interfaces;
using FuneralHome.Data.Repositories;
using FuneralHome.Domain.Interfaces;
using FuneralHome.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuneralHome.Domain.Services
{
    public class FuneralService : IFuneralService
    {
        private readonly IMapper _mapper;       
        private readonly IFuneralRepository _funeralRepository;
        private readonly IEmployeeRepository _employeeRepository;
       
        
        public FuneralService()
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {

                cfg.CreateMap<FuneralModel, Funeral>()
                .ForMember(x => x.FuneralEmployees, opts => opts.MapFrom(src => src.Employees.Select
                 (x => new FuneralEmployee
                 {
                     EmployeeId = x.Id
                 })));
                cfg.CreateMap<Funeral, FuneralModel>().ForMember(x => x.Employees, opts =>
                opts.MapFrom(src => src.FuneralEmployees.Select(x => x.Employee)));
                cfg.CreateMap<ClientModel, Client>().ReverseMap();
                cfg.CreateMap<Employee, EmployeeModel>()
                .ForMember(dest => dest.Position, opts => opts.MapFrom(x => x.PositionId))
                .ReverseMap();

            });

            _mapper = new Mapper(mapperConfig);
            _funeralRepository = new FuneralRepository();
        }

        public FuneralModel Create(FuneralModel model)
        {
            //var startTime = DateTime.UtcNow.Date;
            //var endTime  = startTime.AddHours(24).AddMilliseconds(-1);

            //var startTime = DateTime.UtcNow.AddHours(1);
            //var endTime = DateTime.UtcNow.AddHours(7);
            //var startTime = DateTime.UtcNow.AddHours(1);

            var employeeIds = model.Employees.Select(x => x.Id);
            var employees = _employeeRepository.GetByIds(employeeIds);

            var funerals = employees
                .SelectMany(x => x.FuneralEmployees.Select(y => y.Funeral))
                .Where(x => x.DateUtc == model.DateUtc.Date)
                .ToList();

            foreach (var employee in employees)
            {
                if (employee.FuneralEmployees.Select(x => x.Funeral)
                    .Any(x => x.DateUtc == model.DateUtc.Date));
                throw new System.Exception($"Employee {employee.FirstName} " +
                    $"{employee.LastName} is busy at ths day");

            }

            var funeralMapper = _mapper.Map<Funeral>(model);
            var createdFuneral = _funeralRepository.Create(funeralMapper);

            return _mapper.Map<FuneralModel>(createdFuneral);
             
        }
        public IEnumerable<FuneralModel> GetAll()
        {
            var model = _funeralRepository.GetAll();

            return _mapper.Map<IEnumerable<FuneralModel>>(model);
        }
    }

}

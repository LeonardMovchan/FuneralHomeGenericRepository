using FuneralHome.Data.Entities;
using FuneralHome.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuneralHome.Data.Repositories
{
    class EmployeeRepository : IEmployeeRepository
    {
        private readonly FuneralHomeContext _ctx;

        public EmployeeRepository()
        {
            _ctx = new FuneralHomeContext();
        }

        public IEnumerable<Employee> GetByIds(IEnumerable<int> employeeIds)
        {
            return _ctx.Employees
                .Include(x => x.FuneralEmployees.Select(y => y.Employee))
                .Where(x => employeeIds.Contains(x.Id))
                .AsNoTracking()
                .ToList();
        }
    }
}

using FuneralHome.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuneralHome.Data.Interfaces
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetByIds(IEnumerable<int> employees);
    }
}

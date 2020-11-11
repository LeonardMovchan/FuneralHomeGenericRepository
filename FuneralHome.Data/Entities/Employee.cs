using System.Collections.Generic;

namespace FuneralHome.Data.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public int PositionId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Phone { get; set; }

        public ICollection<FuneralEmployee> FuneralEmployees { get; set; }

    }
}

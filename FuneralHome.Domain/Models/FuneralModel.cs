﻿using FuneralHome.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuneralHome.Domain.Models
{
    public class FuneralModel
    {
        public int Id { get; set; }
        public DateTime DateUtc { get; set; }
        public FuneralTypeEnum Type { get; set; }

        public int ClientId { get; set; }
        public ClientModel Client { get; set; }

        public IEnumerable<EmployeeModel> Employees { get; set; }
    }
}

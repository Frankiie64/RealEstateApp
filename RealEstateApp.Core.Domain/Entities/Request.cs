﻿using RealEstateApp.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateApp.Core.Domain.Entities
{
    public class Request : AuditableBaseEntity
    {
        public string Table { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Estado { get; set; }
    }
}

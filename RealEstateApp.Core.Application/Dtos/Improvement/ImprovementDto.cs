using RealEstateApp.Core.Application.Dtos.Property;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RealEstateApp.Core.Application.Dtos.Improvement
{
    public class ImprovementDto
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        [JsonIgnore]
        public int IdProperty { get; set; }
        [JsonIgnore]
        public PropertyDto Property { get; set; }

    }
}

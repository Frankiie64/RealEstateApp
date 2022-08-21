using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RealEstateApp.Core.Application.Dtos.Improvement
{
    public class CreateImprovementDto
    {
        [Required(ErrorMessage = "Debes ingresar la mejora")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Debes ingresar la Descripcion")]
        public string Description { get; set; }
        [JsonIgnore]
        public int IdProperty { get; set; }
    }
}

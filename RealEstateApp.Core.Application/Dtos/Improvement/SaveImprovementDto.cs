using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateApp.Core.Application.Dtos.Improvement
{
    public class SaveImprovementDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Debes ingresar la mejora")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Debes ingresar la Descripcion")]
        public string Description { get; set; }
    }
}

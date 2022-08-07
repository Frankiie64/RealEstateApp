using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateApp.Core.Application.ViewModels.TypeProperty
{
    public class SaveTypePropertyViewModel
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "Debes ingresar el tipo de Propiedad")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Debes ingresar una Descripcion")]
        public string Description { get; set; }

    }

}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateApp.Core.Application.ViewModels.TypeSale
{
    public class SaveTypeSaleViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Debes ingresar el Tipo de Venta")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Debes ingresar una descripcion")]

        public string Description { get; set; }
    }
}

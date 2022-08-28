using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateApp.Core.Application.ViewModels.Request
{
    public class SaveRequestViewModel
    {
        public int Id { get; set; }
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string Table { get; set; }
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string Name { get; set; }
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string Description { get; set; }
        public bool Estado { get; set; } = false;
        public string CreatedBy { get; set; } = "user";
        public DateTime Creadted { get; set; } = DateTime.Now;
        public bool HasError { get; set; } = false;
        public string Error { get; set; }
    }
}

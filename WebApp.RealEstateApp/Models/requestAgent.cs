using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.RealEstateApp.Models
{
    public class requestAgent
    {

        public string Id { get; set; }
        [Required(ErrorMessage = "Debes ingresar tu Nombre")]
        [DataType(DataType.Text)]
        public string Firstname { get; set; }
        [Required(ErrorMessage = "Debes Ingresar tu Apellido")]
        [DataType(DataType.Text)]
        public string Lastname { get; set; }       
        [Required(ErrorMessage = "Debes Ingresar el numero de telefono")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }       
        public string PhotoProfileUrl { get; set; }
        public IFormFile file { get; set; }
        public bool HasError { get; set; }
        public string Error { get; set; }

    }
}


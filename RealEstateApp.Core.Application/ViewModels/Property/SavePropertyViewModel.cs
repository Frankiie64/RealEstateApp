using Microsoft.AspNetCore.Http;
using RealEstateApp.Core.Application.ViewModels.TypeProperty;
using RealEstateApp.Core.Application.ViewModels.TypeSale;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateApp.Core.Application.ViewModels.Property
{
    public class SavePropertyViewModel
    {
        public int Id { get; set; }
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string Location { get; set; }
        public int Code { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Este campo es obligatorio")]
        public int Room { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Este campo es obligatorio")]
        public double Price { get; set; }
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string Description { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Este campo es obligatorio")]
        public double Meters { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Este campo es obligatorio")]
        public int Bathroom { get; set; }
        public List<string> UrlPhotos { get; set; } = new List<string>();
        public string AgentId { get; set; }
        [DataType(DataType.Upload)]
        public List<IFormFile> File { get; set; } = new List<IFormFile>();
        [Range(1, int.MaxValue, ErrorMessage = "Este campo es obligatorio")]
        public int TypePropertyId { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Este campo es obligatorio")]
        public int TypeSaleId { get; set; }
        public List<int> IdImproments { get; set; } = new List<int>();
        public string CreatedBy { get; set; }
        public DateTime Creadted { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModified { get; set; }
        public bool HasError { get; set; } = false;
        public string Error { get; set; }
    }
}

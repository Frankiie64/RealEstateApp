using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.RealEstateApp.Models
{
    public class RequestPhoto
    {
        public int Id { get; set; }
        public int idProperty { get; set; }
        public IFormFile File { get; set; }
        public string ImgUrl { get; set; }
        public bool HasError { get; set; } = false;
        public string Error { get; set; }
    }
}

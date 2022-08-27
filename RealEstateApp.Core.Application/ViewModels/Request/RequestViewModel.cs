using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateApp.Core.Application.ViewModels.Request
{
    public class RequestViewModel
    {
        public int Id { get; set; }
        public string Table { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Estado { get; set; } = false;
        public string CreatedBy { get; set; } = "user";
        public DateTime Creadted { get; set; } = DateTime.Now;
      
    }
}

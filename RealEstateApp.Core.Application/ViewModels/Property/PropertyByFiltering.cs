using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateApp.Core.Application.ViewModels.Property
{
   public class PropertyByFiltering
    {
        public int code { get; set; } = 0;
        public List<int> IdTypeProperty { get; set; }
        public int MinRooms { get; set; }
        public int MaxRooms { get; set; }
        public int MinBathRooms { get; set; }
        public int MaxBathRooms { get; set; }
        public int MinPrince { get; set; }
        public int MaxPrice { get; set; }
    }
}

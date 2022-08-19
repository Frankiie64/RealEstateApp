using RealEstateApp.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateApp.Core.Domain.Entities
{
    public class Property : AuditableBaseEntity
    {
        public int Code { get; set; }
        public double Price { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public double Meters { get; set; }
        public int Room { get; set; }
        public int Bathroom { get; set; }
        public string AgentId { get; set; }        
        public int TypePropertyId { get; set; }
        public TypeProperty TypeProperty { get; set; }
        public int TypeSaleId { get; set; }
        public TypeSale TypeSale { get; set; }
        public ICollection<TypeImproments> Improments { get; set; }
        public ICollection<PhotosOfProperties> UrlPhotos { get; set; }

    }
}

using RealEstateApp.Core.Domain.Common;
using System.Collections.Generic;

namespace RealEstateApp.Core.Domain.Entities
{
    public class Improvement : AuditableBaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<TypeImproments> typeImproments { get; set; }
    }
}

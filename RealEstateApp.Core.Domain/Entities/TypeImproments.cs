using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateApp.Core.Domain.Entities
{
    public class TypeImproments
    {
        public int Id { get; set; }
        public int IdProperty { get; set; }
        public Property Property { get; set; }
        public int IdImproment { get; set; }
        public Improvement Improvement { get; set; }

    }
}

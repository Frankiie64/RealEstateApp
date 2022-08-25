using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealEstateApp.Core.Application.ViewModels.Users;

namespace RealEstateApp.Core.Application.ViewModels.Agent
{
    public class AgentVM : UserVM
    {
        public int PropertyQuantity { get; set; }
    }
}

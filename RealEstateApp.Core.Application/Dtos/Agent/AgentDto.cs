using RealEstateApp.Core.Application.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateApp.Core.Application.Dtos.Agent
{
    public class AgentDto : UserVM
    {

        public int PropertiesQuantity { get; set; }
    }
}

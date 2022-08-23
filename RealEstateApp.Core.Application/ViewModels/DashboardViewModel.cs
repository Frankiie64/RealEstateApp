using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateApp.Core.Application.ViewModels
{
    public class DashboardViewModel
    {
        public int PropertiesQuantity {get; set;}

        public int AgentActive { get; set; }
        public int AgentDisabled { get; set; }

        public int ClientActive { get; set; }
        public int ClientDisabled { get; set; }

        public int DeveloperActive { get; set; }
        public int DeveloperDisabled { get; set; }


    }
}

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
        //public string Id { get; set; }
        //public string Firstname { get; set; }
        //public string Lastname { get; set; }
        //public string Email { get; set; }
        //public string Phone { get; set; }
        public int PropertiesQuantity { get; set; }
        //public bool IsActive { get; set; }
    }
}

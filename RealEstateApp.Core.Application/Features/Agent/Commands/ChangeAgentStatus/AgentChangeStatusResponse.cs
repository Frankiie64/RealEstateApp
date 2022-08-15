using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RealEstateApp.Core.Application.Features.Agent.Commands.ChangeAgentStatus
{
    public class AgentChangeStatusResponse
    {
        public string Id { get; set; }
        [JsonIgnore]
        public string Firstname { get; set; }
        [JsonIgnore]
        public string Lastname { get; set; }
        [JsonIgnore]
        public string DocumementId { get; set; }
        [JsonIgnore]
        public string Email { get; set; }
        [JsonIgnore]
        public string Username { get; set; }
        [JsonIgnore]
        public string PhoneNumber { get; set; }
        [JsonIgnore]
        public List<string> Roles { get; set; }
        [JsonIgnore]
        public bool IsVerified { get; set; }
        public bool IsActive { get; set; } = true;
        [JsonIgnore]
        public int PropertiesQuantity { get; set; }

    }
}

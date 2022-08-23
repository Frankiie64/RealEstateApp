using RealEstateApp.Core.Application.ViewModels.Property;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RealEstateApp.Core.Application.ViewModels.Users
{
    public class UserVM
    {
        public string Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        [JsonIgnore]
        public string DocumementId { get; set; }
        public string Email { get; set; }
        [JsonIgnore]
        public string PhotoProfileUrl { get; set; }
        public string PhoneNumber { get; set; }
        [JsonIgnore]
        public string Username { get; set; }
        [JsonIgnore]
        public List<string> Roles { get; set; }
        [JsonIgnore]
        public bool IsVerified { get; set; }
        public bool IsActive { get; set; }

        [JsonIgnore]
        public List<PropertyViewModel> Properties { get; set; }
    }
}

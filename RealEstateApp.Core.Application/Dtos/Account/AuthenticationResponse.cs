using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace RealEstateApp.Core.Application.Dtos.Account
{
    public class AuthenticationResponse
    {
        public string Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        [JsonIgnore]
        public string DocumementId { get; set; }
        [JsonIgnore]
        public string PhoneNumber { get; set; }
        public string Username { get; set; }
        [JsonIgnore]
        public string PhotoProfileUrl { get; set; }
        public string Email { get; set; }
        public List<string> Roles { get; set; }
        public bool IsVerified { get; set; }
        public bool IsActive { get; set; }
        public int PropertyQuantity { get; set; }


        public string JWTtoken { get; set; }
        //[JsonIgnore]
        public string RefreshToken { get; set; }
        public bool HasError { get; set; }
        public string Error { get; set; }
    }
}

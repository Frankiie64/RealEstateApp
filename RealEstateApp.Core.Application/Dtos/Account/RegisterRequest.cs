using System.Text.Json.Serialization;

namespace RealEstateApp.Core.Application.Dtos.Account 
{ 
    public class RegisterRequest
    {
        public string Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        [JsonIgnore]
        public string DocumementId { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        [JsonIgnore]
        public string PhotoProfileUrl { get; set; }
        public string ConfirmPassword { get; set; }
        public string PhoneNumber { get; set; }
        [JsonIgnore]
        public bool IsVerified { get; set; } = false;
        [JsonIgnore]
        public bool IsActive { get; set; }

        [JsonIgnore]

        public string Rol { get; set; }
    }
}

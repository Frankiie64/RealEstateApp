using Microsoft.AspNetCore.Identity;


namespace RealEstateApp.Infrastructure.Identity.Entities
{
    public class ApplicationUser: IdentityUser
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string DocumementId { get; set; }
        public string PhotoProfileUrl { get; set; }
        public bool IsActive { get; set; } = false;
    }
}

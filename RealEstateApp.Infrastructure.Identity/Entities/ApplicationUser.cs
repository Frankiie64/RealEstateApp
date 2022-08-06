using Microsoft.AspNetCore.Identity;


namespace RealEstateApp.Infrastructure.Identity.Entities
{
    public class ApplicationUser: IdentityUser
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string DocumementId { get; set; }
    }
}

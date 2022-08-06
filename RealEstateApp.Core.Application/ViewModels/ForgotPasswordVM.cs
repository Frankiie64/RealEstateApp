using System.ComponentModel.DataAnnotations;

namespace RealEstateApp.Core.Application.ViewModels.Users
{
    public class ForgotPasswordVM
    {
        [Required(ErrorMessage = "Debes de colocar el correo del usuario. ")]
        [DataType(DataType.Text)]
        public string Email { get; set; }
        public bool HasError { get; set; }
        public string Error { get; set; }
    }
}

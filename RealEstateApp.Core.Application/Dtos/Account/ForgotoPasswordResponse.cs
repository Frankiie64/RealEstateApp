namespace RealEstateApp.Core.Application.Dtos.Account
{
    public class ForgotPassWordResponse
    {
        public bool HasError { get; set; }
        public string Error { get; set; }
        public string Url { get; set; }
    }
}

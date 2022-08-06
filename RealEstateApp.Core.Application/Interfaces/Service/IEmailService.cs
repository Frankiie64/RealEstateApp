using RealEstateApp.Core.Application.Dtos.Email;
using System.Threading.Tasks;

namespace RealEstateApp.Core.Application.Interfaces.Services
{
    public interface IEmailService
    {
        Task SendAsync(EmailRequest request);
    }
}
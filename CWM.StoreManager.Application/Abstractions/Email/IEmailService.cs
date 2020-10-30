using CWM.StoreManager.Application.DTOs.Email;
using System.Threading.Tasks;

namespace CWM.StoreManager.Application.Abstractions.Email
{
    public interface IEmailService
    {
        Task SendAsync(EmailRequest request);
    }
}
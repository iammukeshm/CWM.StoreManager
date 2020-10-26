using CWM.DotNetCore.Results;
using CWM.StoreManager.Application.DTOs.Account;
using System.Threading.Tasks;

namespace CWM.StoreManager.Application.Abstractions.Account
{
    public interface IAccountService
    {
        Task<Result<AuthenticationResponse>> AuthenticateAsync(AuthenticationRequest request, string ipAddress);
        Task<Result> RegisterAsync(RegisterRequest request, string origin);
        Task<Result> ConfirmEmailAsync(string userId, string code);
        Task ForgotPassword(ForgotPasswordRequest model, string origin);
        Task<Result> ResetPassword(ResetPasswordRequest model);
    }
}

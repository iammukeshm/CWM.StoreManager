using CWM.DotNetCore.Results;
using System.Threading.Tasks;

namespace CWM.StoreManager.Application.Abstractions.Identity
{
    public interface IUserService
    {
        Task<Result<string>> CreateUserAsync(string userName, string password);

        Task<Result> DeleteUserAsync(string userId);
    }
}

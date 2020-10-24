using CWM.Core.Essentials.Results;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CWM.StoreManager.Application.Abstractions.Identity
{
    public interface IUserService
    {
        Task<Result<string>> CreateUserAsync(string userName, string password);

        Task<Result> DeleteUserAsync(string userId);
    }
}

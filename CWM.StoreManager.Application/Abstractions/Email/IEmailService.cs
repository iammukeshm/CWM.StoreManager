using CWM.StoreManager.Application.DTOs.Email;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CWM.StoreManager.Application.Abstractions.Email
{
    public interface IEmailService
    {
        Task SendAsync(EmailRequest request);
    }
}

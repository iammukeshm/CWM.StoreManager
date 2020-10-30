using System.ComponentModel.DataAnnotations;

namespace CWM.StoreManager.Application.DTOs.Account
{
    public class ForgotPasswordRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
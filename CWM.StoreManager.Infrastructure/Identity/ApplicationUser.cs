using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CWM.StoreManager.Infrastructure.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte[] ProfilePicture { get; set; }
        public bool IsActive { get; set; } = false;
        public string ActivatedBy { get; set; }
        public bool IsCustomer { get; set; }
    }
}

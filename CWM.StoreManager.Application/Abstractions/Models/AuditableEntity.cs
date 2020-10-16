using System;
using System.Collections.Generic;
using System.Text;

namespace CWM.StoreManager.Application.Abstractions.Models
{
    public abstract class AuditableEntity
    {
        public string CreatedBy { get; set; }

        public DateTime CreatedUtc { get; set; }

        public string LastModifiedBy { get; set; }

        public DateTime? LastModifiedUtc { get; set; }
    }
}

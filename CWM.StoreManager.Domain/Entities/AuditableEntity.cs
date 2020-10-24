using System;
using System.Collections.Generic;
using System.Text;

namespace CWM.StoreManager.Domain.Entities
{
    public abstract class AuditableEntity : BaseEntity
    {
        public string CreatedBy { get; set; }

        public DateTime CreatedUtc { get; set; }

        public string LastModifiedBy { get; set; }

        public DateTime? LastModifiedUtc { get; set; }
    }
}

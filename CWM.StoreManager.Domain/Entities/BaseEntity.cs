using System;
using System.Collections.Generic;
using System.Text;

namespace CWM.StoreManager.Domain.Entities
{
    public abstract class BaseEntity
    {
        public virtual int Id { get; protected set; }
    }
}

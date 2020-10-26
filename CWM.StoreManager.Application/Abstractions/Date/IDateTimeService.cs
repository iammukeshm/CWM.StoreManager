using System;
using System.Collections.Generic;
using System.Text;

namespace CWM.StoreManager.Application.Abstractions.Date
{
    public interface IDateTimeService
    {
        DateTime NowUtc { get; }
    }
}

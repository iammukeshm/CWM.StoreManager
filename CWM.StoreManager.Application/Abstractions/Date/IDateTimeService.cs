using System;

namespace CWM.StoreManager.Application.Abstractions.Date
{
    public interface IDateTimeService
    {
        DateTime NowUtc { get; }
    }
}
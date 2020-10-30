using CWM.StoreManager.Application.Abstractions.Date;
using System;

namespace CWM.StoreManager.Infrastructure.Dates
{
    public class SystemDateTimeService : IDateTimeService
    {
        public DateTime NowUtc => DateTime.UtcNow;
    }
}
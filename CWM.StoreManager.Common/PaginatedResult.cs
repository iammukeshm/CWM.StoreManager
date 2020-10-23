using System;
using System.Collections.Generic;
using System.Text;

namespace CWM.StoreManager.Common
{
    public class PaginatedResult<T> : Result
    {
        public T Data { get; set; }

        internal PaginatedResult(bool succeeded, T data = default, IEnumerable<string> errors = null,  long count = 0, int pageIndex = 0, int pageSize= 0) : base(succeeded, errors)
        {
            Data = data;
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            TotalItems = count;
            PageItemsStartsAt = count > 0 ? ((pageIndex - 1) * pageSize) + 1 : 0;
            PageItemsEndsAt = 0;
            if (count > 0)
            {
                if (pageIndex * pageSize > count)
                {
                    PageItemsEndsAt = count;
                }
                else
                {
                    PageItemsEndsAt = pageIndex * pageSize;
                }
            }
        }

        public static new PaginatedResult<T> Failure(IEnumerable<string> errors)
        {
            if (errors == null)
            {
                throw new ArgumentNullException(nameof(errors));
            }
            return new PaginatedResult<T>(false, default, errors);
        }

        public static new PaginatedResult<T> Success(T data, long count, int pageIndex, int pageSize)
        {

            return new PaginatedResult<T>(true, data, null, count, pageIndex, pageSize);
        }

        public int PageIndex { get; set; }

        public int TotalPages { get; set; }

        public long TotalItems { get; set; }

        public int MaxPageLink { get; } = 5;

        public long PageItemsStartsAt { get; set; }

        public long PageItemsEndsAt { get; set; }

        public bool HasPreviousPage => PageIndex > 1;

        public bool HasNextPage => PageIndex < TotalPages;
    }
}

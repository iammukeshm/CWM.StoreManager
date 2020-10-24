using System;
using System.Collections.Generic;
using System.Text;

namespace CWM.StoreManager.Common
{
    public class PaginatedResult<T> : Result
    {
        public T Data { get; set; }

        internal PaginatedResult(bool succeeded, T data = default, IEnumerable<string> errors = null,  long count = 0, int page = 1, int pageSize= 10) : base(succeeded, errors)
        {
            Data = data;
            Page = page;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            TotalItems = count;
            PageItemsStartsAt = count > 0 ? ((page - 1) * pageSize) + 1 : 0;
            PageItemsEndsAt = 0;
            if (count > 0)
            {
                if (page * pageSize > count)
                {
                    PageItemsEndsAt = count;
                }
                else
                {
                    PageItemsEndsAt = page * pageSize;
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

        public static PaginatedResult<T> Success(T data, long count, int page, int pageSize)
        {

            return new PaginatedResult<T>(true, data, null, count, page, pageSize);
        }

        public int Page { get; set; }

        public int TotalPages { get; set; }

        public long TotalItems { get; set; }

        public long PageItemsStartsAt { get; set; }

        public long PageItemsEndsAt { get; set; }

        public bool HasPreviousPage => Page > 1;

        public bool HasNextPage => Page < TotalPages;
    }
}

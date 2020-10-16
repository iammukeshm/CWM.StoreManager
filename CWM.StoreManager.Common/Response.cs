using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CWM.StoreManager.Common
{
    public class Response
    {
        public string[] Errors { get; } = new string[0];

        public bool Succeeded { get; }

        internal Response(bool succeeded, IEnumerable<string> errors = null)
        {
            Succeeded = succeeded;
            Errors = (errors ?? Enumerable.Empty<string>()).ToArray();
        }

        public static Response Failure(IEnumerable<string> errors)
        {
            if (errors == null)
            {
                throw new ArgumentNullException(nameof(errors));
            }
            return new Response(false, errors);
        }

        public static Response Success() => new Response(true);
    }
    public class Response<T> : Response
    {
        public T Data { get; }

        internal Response(bool succeeded, T data = default, IEnumerable<string> errors = null) : base(succeeded, errors) => Data = data;

        public static new Response<T> Failure(IEnumerable<string> errors)
        {
            if (errors == null)
            {
                throw new ArgumentNullException(nameof(errors));
            }
            return new Response<T>(false, default, errors);
        }

        public static Response<T> Success(T data) => new Response<T>(true, data);
    }
}

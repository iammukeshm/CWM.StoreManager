using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CWM.StoreManager.Common
{
    public class Result
    {
        public string[] Errors { get; } = new string[0];
        public bool Succeeded { get; }
        internal Result(bool succeeded, IEnumerable<string> errors = null)
        {
            Succeeded = succeeded;
            Errors = (errors ?? Enumerable.Empty<string>()).ToArray();
        }
        public static Result Failure(IEnumerable<string> errors)
        {
            if (errors == null)
            {
                throw new ArgumentNullException(nameof(errors));
            }
            return new Result(false, errors);
        }
        public static Result Success() => new Result(true);
    }
    public class Result<T> : Result
    {
        public T Data { get; }
        internal Result(bool succeeded, T data = default, IEnumerable<string> errors = null) : base(succeeded, errors) => Data = data;
        public static new Result<T> Failure(IEnumerable<string> errors)
        {
            if (errors == null)
            {
                throw new ArgumentNullException(nameof(errors));
            }
            return new Result<T>(false, default, errors);
        }
        public static Result<T> Success(T data) => new Result<T>(true, data);
    }
}

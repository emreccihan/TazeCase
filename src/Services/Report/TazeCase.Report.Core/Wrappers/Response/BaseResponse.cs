using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TazeCase.Report.Core.Wrappers.Response
{
    public class BaseResponse<T>
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public T Body { get; set; }
        public int? TotalCount { get; set; }

        public static BaseResponse<T> Success(T data, string message = null, int? totalCount = null)
        {
            return new BaseResponse<T>
            {
                Status = 200,
                Message = message ?? "Success",
                Body = data,
                TotalCount = totalCount
            };
        }

        public static BaseResponse<T> Error(string errorMessage, int statusCode = 400)
        {
            return new BaseResponse<T>
            {
                Status = statusCode,
                Message = errorMessage,
                Body = default
            };
        }
    }
}

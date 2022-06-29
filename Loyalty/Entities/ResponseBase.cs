using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loyalty.Entities
{
    public class ResponseBase<T>
    {
        public SuccessType Success { get; set; }
        public string Message { get; set; }
        public T? Data { get; set; }
    }


    public class RequestPaging
    {
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
    }

    public enum SuccessType
    {
        Failed = 0,
        Success = 1
    }
}

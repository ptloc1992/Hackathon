using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace WebApi.Dtos.Base
{
    public class ResponseBase<T>
    {
        public T Data { get; set; }
        public string Message { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public ErrorBase Error { get; set; }
    }
}

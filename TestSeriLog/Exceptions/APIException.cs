using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace TestSeriLog.Exceptions
{
    public class APIException : Exception
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
        public string ToJson()
        {
            return JsonSerializer.Serialize(this);
        }
        public APIException(int StatusCode ,string Message, object Data = null)
        {
            this.StatusCode = StatusCode;
            this.Message = Message;
            this.Data = Data;
        }

    }
}
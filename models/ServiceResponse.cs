using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmdApi.models
{
    public class ServiceResponse<T>
    {
        public T? Data { get; set; }
        public bool Successful { get; set; } = true;
        public string Message { get; set; } = string.Empty;
    }
}
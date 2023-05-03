using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qualisha.iCommunity.Data.Models.Dtos
{
    public class ResponseWrapper
    {
        public ResponseWrapper()
        {
            Message = string.Empty;
        }
        public string Message { get; set; }
        public object? Results { get; set; } 
        public bool Success { get; set; }
    }
}

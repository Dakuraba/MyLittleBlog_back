using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLittleBlog_back.Domain.Entity
{
    public class CommandResponse
    { 
        public int ID { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}

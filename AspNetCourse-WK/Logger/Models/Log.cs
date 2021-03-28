using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Models
{
    internal class Log
    {
        public int Id { get; set; }
        public DateTime TimeStamp { get; set; }
        public string LogLevel { get; set; }
        public string ExecutingType { get; set; }
        public string UserName { get; set; }
        public string Exception { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
    }
}

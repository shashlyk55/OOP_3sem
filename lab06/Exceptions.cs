using System;
using System.Collections.Generic;
using System.Diagnostics.PerformanceData;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab06
{
    internal class SortException : Exception
    {
        private string message;
        public string Message { get { return message; } }
        public SortException(string Message) : base(Message)
        {
            message = Message;
        }
    }
    internal class ArrayException : Exception
    {
        public readonly string outOfRange = "Выход индекса за допустимые пределы";
        private string message;
        public string Message { get { return message; } }
        public ArrayException(string Message = "") : base(Message)
        {
            message = Message;
        }
    }
    internal class NumberException : Exception
    {
        private string message;
        public string Message { get { return message; } }
        public NumberException(string Message) : base(Message)
        {
            message = Message;
        }
    }
}

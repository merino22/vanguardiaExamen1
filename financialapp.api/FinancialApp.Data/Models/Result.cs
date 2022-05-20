using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialApp.Data.Models
{
    public class Result<T>
    {
        public Result(string message)
        {
            ErrorMessage = message;
            Success = false;
        }

        public Result(T value)
        {
            Value = value;
            Success = true;
        }

        public bool Success { get; set; }

        public string ErrorMessage { get; set; }

        public T Value { get; set; }
    }
}

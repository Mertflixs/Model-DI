using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ppr_Model.Services
{
    public class DBLogger : ILoggerService
    {
        public void Write(string message)
        {
            Console.WriteLine("[DBLogger] - " + message);
        }
    }
}
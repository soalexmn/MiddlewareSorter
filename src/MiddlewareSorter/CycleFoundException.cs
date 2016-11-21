using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Soalexmn.MiddlewareSorter
{
    public class CycleFoundException : Exception
    {
        public Type ErrorOnType { get; private set; }
        public CycleFoundException(string message, Type type) : base(message)
        {
            ErrorOnType = type;
        }
    }
}

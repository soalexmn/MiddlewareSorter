using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Soalexmn.MiddlewareSorter
{
    public class MiddlewareDescription
    {
        public MiddlewareDescription()
        {

        }
        public MiddlewareDescription(Type type)
        {
            Type = type;
        }
        
        public Type Type { get; set; }
        public object[] Arguments { get; set; }

        public List<Type> MustBeBefore { get; set; } = new List<Type>();
        public List<Type> MustBeAfter { get; set; } = new List<Type>();

        public static MiddlewareDescription Create<T>()
        {
            return new MiddlewareDescription { Type = typeof(T) };
        }

        public static MiddlewareDescription Create<T>(params object[] args)
        {
            return new MiddlewareDescription { Type = typeof(T), Arguments = args };
        }

        public MiddlewareDescription Before<T>()
        {
            MustBeBefore.Add(typeof(T));
            return this;
        }
        public MiddlewareDescription After<T>()
        {
            MustBeAfter.Add(typeof(T));
            return this;
        }

    }
}

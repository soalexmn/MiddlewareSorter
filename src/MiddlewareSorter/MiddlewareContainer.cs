using Soalexmn.MiddlewareSorter.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("MiddlewareSorter.Tests")]

namespace Soalexmn.MiddlewareSorter
{
   
    public class MiddlewareContainer
    {
        internal List<MiddlewareDescription> Pairs { get; private set; }

        public MiddlewareContainer()
        {
            Pairs = new List<MiddlewareDescription>();
        }

        public MiddlewareContainer(IEnumerable<MiddlewareDescription> items)
        {
            Pairs = items.ToList();
        }

        public void Add(MiddlewareDescription item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            Pairs.Add(item);
        }

        public void Add<T>(params object[] args)
        {
            Pairs.Add(new MiddlewareDescription { Type = typeof(T), Arguments = args });
        }

        public void AddWithTerms<T>(IEnumerable<Type> mustBeBefore, IEnumerable<Type> mustBeAfter, params object[] args)
        {
            Pairs.Add(new MiddlewareDescription
            {
                Type = typeof(T),
                Arguments = args,
                MustBeBefore = mustBeBefore.ToList(),
                MustBeAfter = mustBeAfter.ToList()
            });
        }

        public void AddRange(IEnumerable<MiddlewareDescription> collection)
        {
            if (collection == null) throw new ArgumentNullException(nameof(collection));
            Pairs.AddRange(collection);
        }


        public MiddlewareDescription[] GetSorted()
        {
            Graf graf = new Graf(Pairs);
            return graf.CalcResult();
        }

    }
}

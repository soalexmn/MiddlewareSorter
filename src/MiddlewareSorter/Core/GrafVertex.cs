using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Soalexmn.MiddlewareSorter.Core
{
    class GrafVertex
    {
        public GrafVertex()
        {
            NextVertexes = new List<GrafVertex>();
        }

        public MiddlewareDescription Description { get; set; }

        public VertexType VertexType { get; set; }

        public List<GrafVertex> NextVertexes { get; set; }
    }
}

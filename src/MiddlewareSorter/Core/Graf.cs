using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Soalexmn.MiddlewareSorter.Core
{
    class Graf
    {
        protected List<GrafVertex> WhiteSet { get; set; } = new List<GrafVertex>();
        protected Stack<GrafVertex> Result { get; set; } = new Stack<GrafVertex>();

        public Graf(IEnumerable<MiddlewareDescription> descriptions)
        {
            foreach (var item in descriptions)
            {
                GrafVertex vertex = new GrafVertex { Description = item, VertexType = VertexType.White };
                WhiteSet.Add(vertex);
            }
            CreateGraf();
        }

        public MiddlewareDescription[] CalcResult()
        {
            while (WhiteSet.Count > 0)
            {
                var vertex = WhiteSet.First();
                Visit(vertex);
            }
            return Result.Select(v => v.Description).Reverse().ToArray();
        }

        private void Visit(GrafVertex vertex)
        {
            if (vertex.VertexType != VertexType.White)
            {
                throw new Exception("Wrong algorithm work!");
            }
            vertex.VertexType = VertexType.Gray;
            foreach (var nextVertex in vertex.NextVertexes)
            {
                if (nextVertex.VertexType == VertexType.Gray)
                {
                    ThrowCycleError(nextVertex.Description.Type);
                }
                else if (nextVertex.VertexType == VertexType.Black)
                {
                    continue;
                }
                else
                {
                    Visit(nextVertex);
                }
            }
            vertex.VertexType = VertexType.Black;
            WhiteSet.Remove(vertex);
            Result.Push(vertex);
        }

        private void ThrowCycleError(Type type)
        {
            throw new CycleFoundException($"Found loop on type: {type.FullName}", type);
        }

        private void CreateGraf()
        {
            foreach (var vertex in WhiteSet)
            {
                vertex.NextVertexes.AddRange(WhiteSet.Where(v => vertex.Description.MustBeAfter.Contains(v.Description.Type)));

                foreach (var typeBefore in vertex.Description.MustBeBefore)
                {
                    var vertexBefore = WhiteSet.FirstOrDefault(v => v.Description.Type == typeBefore);
                    vertexBefore?.NextVertexes.Add(vertex);
                }
            }
        }

        
    }
}

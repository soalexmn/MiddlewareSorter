using Soalexmn.MiddlewareSorter.Tests.TestClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Soalexmn.MiddlewareSorter.Tests
{

    public class ContainerTests
    {

        [Fact]
        public void ContainerCreate_ContructorsWorks()
        {
            MiddlewareContainer container = new MiddlewareContainer();
            container = new MiddlewareContainer(Enumerable.Empty<MiddlewareDescription>());
        }

        [Fact]
        public void ContainerAdd_Smth_AddedOne()
        {
            var container = new MiddlewareContainer();

            container.Add(new MiddlewareDescription());

            Assert.Equal(container.Pairs.Count, 1);
        }

        [Fact]
        public void ContainerAdd_Null_ThrowsException()
        {
            var container = new MiddlewareContainer();
            Assert.Throws<ArgumentNullException>(() => container.Add(null));
        }

        [Fact]
        public void ContainerAdd_FourMiddlewares_FourPairs()
        {
            var container = new MiddlewareContainer();

            container.AddWithTerms<Second>(new[] { typeof(First) }, new[] { typeof(Third) });
            container.Add<First>();
            container.Add<Third>();
            container.Add<Fourth>();

            Assert.Equal(container.Pairs.Count, 4);
        }
    }
}

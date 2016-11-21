using Soalexmn.MiddlewareSorter.Tests.TestClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Soalexmn.MiddlewareSorter.Tests
{
    public class SortingTests
    {
        [Fact]
        public void GetSorted_OneTwoThreeExpected()
        {
            MiddlewareContainer container = new MiddlewareContainer();
            container.Add(MiddlewareDescription.Create<Second>().Before<Third>().After<First>());
            container.Add(MiddlewareDescription.Create<First>());
            container.Add(MiddlewareDescription.Create<Third>());

            var result = container.GetSorted();

            Assert.Equal(result[0].Type, typeof(First));
            Assert.Equal(result[1].Type, typeof(Second));
            Assert.Equal(result[2].Type, typeof(Third));
        }

    }
}

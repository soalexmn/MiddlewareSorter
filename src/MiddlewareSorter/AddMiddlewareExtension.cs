using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Soalexmn.MiddlewareSorter
{
    public static class AddMiddlewareExtension
    {
        public static IApplicationBuilder UseSortedMiddleware(this IApplicationBuilder app, MiddlewareContainer container)
        {
            foreach (var middleware in container.GetSorted())
            {
                app.UseMiddleware(middleware.Type, middleware.Arguments);
            }
            return app;
        }
    }
}

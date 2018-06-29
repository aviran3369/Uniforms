using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Text;

namespace Uniforms.Core.Route
{
    public interface IRouterManager
    {
        void MapRoute(IRouteBuilder builder);
    }
}

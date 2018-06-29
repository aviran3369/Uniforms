using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Uniforms.Core.Route
{
    public static class RouterService
    {
        public static List<IRouterManager> GetAllRouterManagerImplementations()
        {
            List<IRouterManager> instances = new List<IRouterManager>();

            var all =
                Assembly
                .GetEntryAssembly()
                .GetReferencedAssemblies()
                .Select(Assembly.Load)
                .SelectMany(x => x.DefinedTypes)
                .Where(type => typeof(IRouterManager).IsAssignableFrom(type.AsType()) && type.IsClass && !type.IsAbstract);

            foreach (var ti in all)
            {
                var t = ti.AsType();
                if (!t.Equals(typeof(IRouterManager)))
                {
                    IRouterManager instance = (IRouterManager)Activator.CreateInstance(t);
                    instances.Add(instance);
                }
            }

            return instances;
        }
    }
}

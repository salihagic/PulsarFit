using System;
using System.Collections.Generic;
using System.Linq;

namespace PulsarFit.COMMON.Helpers
{
    public static class FunctionalitiesResolver
    {
        public static IEnumerable<Functionality> Functionalities(Type[] assemblies, Type[] baseTypes)
        {
            return assemblies.SelectMany(a => 
                a.Assembly.GetTypes().Where(x =>
                !baseTypes.Any(y => y.IsAssignableFrom(x)) &&
                x.IsController())
                .SelectMany(x => x.GetControllerActions()))
                .OrderBy(x => x.Assembly).ThenBy(x => x.Controller).ThenBy(x => x.Action)
                .ToList();
        }
    }
}

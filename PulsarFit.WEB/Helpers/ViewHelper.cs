using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PulsarFit.CORE.Domain;
using PulsarFit.DAL.Services;

namespace PulsarFit.WEB.Helpers
{
    public class ViewHelper
    {
        public async Task<string> SerializeToCamelCase(object items)
        {
            return JsonConvert.SerializeObject(items, PulsarFit.COMMON.Helpers.Extensions.JsonSerializerSettings);
        }

        IServiceProvider _serviceProvider;

        public ViewHelper(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
    }
}

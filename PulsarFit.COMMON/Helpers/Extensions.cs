using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq.Dynamic.Core;
using System.Net;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PulsarFit.COMMON.Helpers
{
    public static class Extensions
    {
        public static Action<MvcNewtonsoftJsonOptions> MvcNewtonsoftJsonOptions => options => options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        
        public static JsonSerializerSettings JsonSerializerSettings => new JsonSerializerSettings
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            }
        };

        public static string ToCamelCase(this string s) => string.IsNullOrEmpty(s) ? string.Empty : $"{s[0].ToString().ToLower()}{s.Substring(1)}";
        
        public static string RemoveControllerSufix(this string controllerName)
        {
            var index = controllerName.IndexOf("Controller");
            if (index == -1)
                return string.Empty;
            return controllerName.Substring(0, index);
        }

        public static bool HasAllowAnonymousAttribute(this ActionExecutingContext context)
        {
            var isControllerAllowedAnonymous = context.Controller.GetType().CustomAttributes.Select(x => x.AttributeType).ToList().Contains(typeof(AllowAnonymousAttribute));
            var isActionAllowedAnonymous = context.ActionDescriptor.EndpointMetadata.Select(x => x.GetType()).ToList().Contains(typeof(AllowAnonymousAttribute));

            return (isControllerAllowedAnonymous || isActionAllowedAnonymous);
        }

        public static void SetUnauthorized(this ActionExecutingContext context)
        {
            context.HttpContext.ClearToken();
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
        }

        public static void ClearToken(this HttpContext httpContext)
        {
            if (httpContext.Response.Headers.ContainsKey("Authorization"))
                httpContext.Response.Headers.Remove("Authorization");
        }

        public static void ClearTokenCookie(this HttpContext httpContext)
        {
            httpContext.Session.Clear();
            httpContext.Response.Cookies.Delete("Authorization");
        }

        public static void ReSetJwt(this HttpContext httpContext, string jwt)
        {
            httpContext.ClearToken();
            httpContext.Response.Headers.Add("Authorization", $"Bearer {jwt}");
        }

        public static void ReSetJwtCookie(this HttpContext httpContext, string jwt, int jwtExpirationInDays = 1000)
        {
            httpContext.Response.Cookies.Append(
                        "Authorization",
                        $"Bearer {jwt}",
                        new CookieOptions { 
                            Path = "/", 
                            Expires = DateTime.Now.AddDays(jwtExpirationInDays), 
                            HttpOnly = true,
                            IsEssential = true,
                            Domain = httpContext.Request.Host.Host
                        }
                    );
        }

        public static bool IsController(this Type type)
        {
            if (typeof(ControllerBase).IsAssignableFrom(type))
                return true;

            while (type.BaseType != null)
            {
                if (typeof(ControllerBase).IsAssignableFrom(type))
                    return true;
                type = type.BaseType;
            }

            return false;
        }

        public static IEnumerable<Functionality> GetActions(this Type type, string controllerName = "")
        {
            var assemblyName = type.Assembly.GetName().Name;

            return type.GetMethods(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public)
                   .Where(m => !m.GetCustomAttributes(typeof(System.Runtime.CompilerServices.CompilerGeneratedAttribute), true).Any())
                   .Select(x =>
                   new
                   {
                       Action = x.Name
                   })
                   .Distinct()
                   .Select(x =>
                   new Functionality
                   {
                       Assembly = assemblyName,
                       Controller = controllerName.RemoveControllerSufix(),
                       Action = x.Action,
                   });
        }

        public static IEnumerable<Functionality> GetControllerActions(this Type type)
        {
            var actions = new List<Functionality>();

            var controllerName = type.Name;

            while (type != null && type != typeof(ControllerBase) && type != typeof(ControllerBase))
            {
                actions.AddRange(type.GetActions(controllerName));
                type = type.BaseType;
            }

            return actions;
        }

        public static void SetObject(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));
        }

        public static T GetObject<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }
}

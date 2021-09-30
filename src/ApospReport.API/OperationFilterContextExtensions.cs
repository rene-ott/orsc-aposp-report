using System;
using System.Collections.Generic;
using System.Reflection;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ApospReport.API
{
    internal static class OperationFilterContextExtensions
    {
        public static IEnumerable<T> GetControllerAttributes<T>(this OperationFilterContext context) where T : Attribute
        {
            var controllerAttributes = context.MethodInfo.DeclaringType.GetTypeInfo().GetCustomAttributes<T>();

            var result = new List<T>(controllerAttributes);
            return result;
        }
    }
}

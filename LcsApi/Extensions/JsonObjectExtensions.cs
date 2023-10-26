using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LcsApi.Extensions
{
    public static class JsonObjectExtensions
    {
        /// <summary>
        /// Converts an object to a JSON string
        /// </summary>
        /// <param name="obj">Object to be serialized</param>
        /// <returns>JSON string representation ob the given object</returns>
        public static string ToJson(this object obj)
        {
            return JsonSerializer.Serialize(obj, new JsonSerializerOptions()
            {
                WriteIndented = true
            });
        }
    }
}

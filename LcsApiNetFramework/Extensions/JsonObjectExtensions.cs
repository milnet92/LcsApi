using Newtonsoft.Json;

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
            return JsonConvert.SerializeObject(obj, Formatting.Indented);
        }
    }
}

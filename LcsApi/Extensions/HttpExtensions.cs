using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LcsApi.Extensions
{
    public static class HttpExtensions
    {
        public static HttpResponseMessage EnsureLcsSuccessStatusCode(this HttpResponseMessage response)
        {
            if (response.StatusCode != System.Net.HttpStatusCode.OK && response.StatusCode != System.Net.HttpStatusCode.InternalServerError)
            {
                response.EnsureSuccessStatusCode();
            }

            return response;
        }
    }
}

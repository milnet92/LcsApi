using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LcsApi.Clients
{
    public class LcsConnectionOptions
    {
        public const string DefaultLcsUrl = "https://lcs.dynamics.com";

        public static readonly LcsConnectionOptions Default = new();

        /// <summary>
        /// Connection timeout in seconds
        /// </summary>
        public int ConnectionTimeout { get; set; } = 60 * 2; // 2 minutes

        /// <summary>
        /// Base LifeCycle Services URL
        /// </summary>
        public string LcsUrl { get; set; } = DefaultLcsUrl;
    }
}

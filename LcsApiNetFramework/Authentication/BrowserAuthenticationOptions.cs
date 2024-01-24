using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace LcsApi.Authentication
{
    public class BrowserAuthenticationOptions : IBrowserAuthenticationOptions
    {
        public const string DefaultLoginUrl = "https://lcs.dynamics.com/Logon/AdLogon";

        public string Username { get; set; }
        public string Password { get; set; }
        public string LoginUrl { get; set; }
        public string Cookies { get; set; }
        public bool Headless { get; set; }
        public BrowserAuthenticationOptions(string username, string password, string loginUrl = DefaultLoginUrl)
        {
            Username = username;
            Password = password;
            LoginUrl = loginUrl;
        }

        public BrowserAuthenticationOptions(string cookies, string loginUrl = DefaultLoginUrl)
        {
            Cookies = cookies;
            LoginUrl = loginUrl;
        }

        /// <summary>
        /// Creates a new <see cref="WebDriver"/> instance. You can override this method to provide your own driver options and service.
        /// </summary>
        /// <returns><see cref="WebDriver"/> instance</returns>
        public virtual WebDriver CreateWebDriver()
        {
            var service = EdgeDriverService.CreateDefaultService();
            service.HideCommandPromptWindow = true;

            var options = new EdgeOptions();
            options.AddArguments("no-sandbox", "disable-dev-shm-usage", "inprivate");

            if (Headless)
            {
                options.AddArguments("--headless");
            }

            return new EdgeDriver(service, options);
        }
    }
}

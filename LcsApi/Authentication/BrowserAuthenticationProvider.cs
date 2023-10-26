using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using LcsApi.Extensions;

namespace LcsApi.Authentication
{
    public class BrowserAuthenticationProvider : IBrowserAuthenticationProvider
    {
        private const string LCS_WEB_TITLE = "Microsoft Dynamics Lifecycle Services";
        private const string LCS_WEB_USERNAME_ENTRY = "loginfmt";
        private const string LCS_WEB_PASSWORD_ENTRY = "passwd";
        private const string LCS_WEB_LOGIN_BUTTON = "idSIButton9";
        private const string LCS_VERIFICATION_CODE_XPATH = "/html/body/input[@name='__RequestVerificationToken']";

        public string LoginUrl => _options.LoginUrl;

        private readonly BrowserAuthenticationOptions _options;
        public IBrowserAuthenticationOptions Options => _options;

        private string? _cookies;

        /// <summary>
        /// Cookies for the current user
        /// </summary>
        public string Cookies
        {
            get
            {
                return GetCookies();
            }
        }

        public BrowserAuthenticationProvider(BrowserAuthenticationOptions options)
        {
            _options = options ?? throw new ArgumentNullException(nameof(options));
            _cookies = options.Cookies;
        }

        /// <summary>
        /// Gets the cookies for the current user. If cookies already exist, they are used instead of creating new ones.
        /// </summary>
        /// <returns>Cookie string</returns>
        public string GetCookies()
        {
            // If cookies already exist, return them
            if (_cookies is not null) return _cookies;

            string cookie = string.Empty;

            var driver = Options.CreateWebDriver();

            try
            { 
                driver.Navigate().GoToUrl(_options.LoginUrl);
                Thread.Sleep(2000);

                driver.FindElement(By.Name(LCS_WEB_USERNAME_ENTRY), 5).SendKeys(_options.Username);
                driver.FindElement(By.Id(LCS_WEB_LOGIN_BUTTON), 5).Click();

                driver.FindElement(By.Name(LCS_WEB_PASSWORD_ENTRY), 5).SendKeys(_options.Password);

                while (true)
                {
                    try
                    {
                        driver.FindElement(By.Id(LCS_WEB_LOGIN_BUTTON), 2).Click();
                        break;
                    }
                    catch
                    {
                        Thread.Sleep(1000);
                    }
                }

                // TODO: This is to handle MFA. We need to find a better way to handle this.
                try
                {
                    Thread.Sleep(1000);

                    new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(drv =>
                    {
                        try
                        {
                            return drv.FindElement(By.Id("idRichContext_DisplaySign")).Text != null;
                        }
                        catch
                        {
                            return false;
                        }
                    });

                    IWebElement num = driver.FindElement(By.Id("idRichContext_DisplaySign"));

                    if (num != null && num.Text != null)
                    {
                        Console.WriteLine($"Please provide the following number to your Authenticator: {num.Text}");
                    }
                }
                catch
                {
                    // Do nothing
                }

                var titleWait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                titleWait.Until(drv => drv.Title == LCS_WEB_TITLE);
                var element = driver.FindElement(By.XPath(LCS_VERIFICATION_CODE_XPATH), 2);

                var cookies = driver.Manage().Cookies.AllCookies;

                for (int i = 0; i < cookies?.Count; i++)
                {
                    if (i != 0)
                    {
                        cookie += ",";
                    }

                    cookie += $"{cookies[i].Name}={cookies[i].Value}";
                }
            }
            catch
            {
                // NO-OP
            }
            finally
            {
                if (driver != null)
                {                     
                    driver.Quit();
                }
            }
            _cookies = cookie;

            return _cookies;
        }
    }
}

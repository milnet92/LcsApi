using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace LcsApi.Extensions
{
    internal static class WebDriverExtensions
    {
        /// <summary>
        /// Finds an element using a given <see cref="By"/> selector and waits for it to be visible
        /// </summary>
        /// <param name="driver">Web driver instance</param>
        /// <param name="by">Selector</param>
        /// <param name="timeoutInSeconds">Maximum wait time</param>
        /// <returns></returns>
        public static IWebElement FindElement(this IWebDriver driver, By by, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(drv => drv.FindElement(by));
            }

            return driver.FindElement(by);
        }
    }
}

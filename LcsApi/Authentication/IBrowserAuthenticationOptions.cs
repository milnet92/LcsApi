using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace LcsApi.Authentication
{
    public interface IBrowserAuthenticationOptions
    {
        public WebDriver CreateWebDriver();
    }
}

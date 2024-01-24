using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LcsApi.Authentication
{
    public interface IBrowserAuthenticationProvider
    {
        IBrowserAuthenticationOptions Options { get; }
        string LoginUrl{ get; }
        string GetCookies();
    }
}

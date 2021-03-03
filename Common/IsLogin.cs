using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class IsLogin
    {
        public bool IsUserLogin()
        {
            var _Result = SessionProxyUser.IsUserLogin;
            if (_Result == true)
            {
                return true;
            }
            return false;
        }
    }
}

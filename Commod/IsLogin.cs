using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Common
{
    public class isLogin
    {
        public bool IsUserLogin()
        {
            var _Result = SessionProxyUser.IsUserLogin;
            if (_Result==true)
            {
                return true;
            }
            return false;
        }
    }
}
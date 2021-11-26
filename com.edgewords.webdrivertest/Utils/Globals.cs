using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace com.edgewords.webdrivertest.Utils
{
    public static class Globals
    {
        public static string GLOBAL_BASE_URL
        {
            get { return ConfigurationManager.AppSettings["BaseAddress"]; }
        }
        public static int GLOBAL_TIMEOUT
        {
            get { return Convert.ToInt32 (ConfigurationManager.AppSettings["GblTimeout"]); }
        }
    }
}

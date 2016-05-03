using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Collections.Specialized;

namespace TechnicalTestQualityAssistance.Configuration
{
    class ConfigurationProvider
    {
        private static ConfigurationProvider _instance = null;
        
        public static ConfigurationProvider Instance
        {
            get
            {
                if (_instance == null)
                {
                    var logins = ConfigurationManager.GetSection("Logins") as NameValueCollection;
                    var urls = ConfigurationManager.GetSection("Urls") as NameValueCollection;
                    var waits = ConfigurationManager.GetSection("Waits") as NameValueCollection;
                    _instance = new ConfigurationProvider();
                    _instance.Logins = logins;
                    _instance.Urls = urls;
                    _instance.Waits = waits;
                }

                return _instance;
            }
        }

        public NameValueCollection Logins { get; private set; }

        public NameValueCollection Urls { get; private set; }

        public NameValueCollection Waits { get; private set; }
    }
}

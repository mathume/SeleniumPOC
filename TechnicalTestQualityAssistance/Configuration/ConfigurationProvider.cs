﻿using System;
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
        
        private ConfigurationProvider(NameValueCollection logins, NameValueCollection urls)
        {
            this.Logins = logins;
            this.Urls = urls;
        }
        
        public static ConfigurationProvider Instance
        {
            get
            {
                if (_instance == null)
                {
                    var logins = ConfigurationManager.GetSection("Logins") as NameValueCollection;
                    var urls = ConfigurationManager.GetSection("Urls") as NameValueCollection;
                    _instance = new ConfigurationProvider(logins, urls);
                }

                return _instance;
            }
        }

        public NameValueCollection Logins { get; private set; }

        public NameValueCollection Urls { get; private set; }
    }
}
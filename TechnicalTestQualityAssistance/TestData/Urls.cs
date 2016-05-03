using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using TechnicalTestQualityAssistance.Configuration;

namespace TechnicalTestQualityAssistance.TestData
{
    class Urls
    {
        static NameValueCollection urls = ConfigurationProvider.Instance.Urls;
        public static string TestSpaceUrl
        {
            get
            {
                return urls.Get("TestSpaceUrl");
            }
        }
    }
}

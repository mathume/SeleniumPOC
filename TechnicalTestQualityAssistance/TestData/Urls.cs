using System.Collections.Specialized;
using TecTest.Utilities.Configuration;

namespace TechnicalTestQualityAssistance.TestData
{
    internal class Urls
    {
        private static NameValueCollection urls = ConfigurationProvider.Instance.Urls;

        public static string TestSpaceUrl
        {
            get
            {
                return urls.Get("TestSpaceUrl");
            }
        }
    }
}
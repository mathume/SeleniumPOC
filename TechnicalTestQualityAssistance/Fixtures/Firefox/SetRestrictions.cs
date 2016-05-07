using OpenQA.Selenium.Firefox;
using TecTest.Utilities.Drivers;

namespace TechnicalTestQualityAssistance.Fixtures.Firefox
{
    internal class SetRestrictions : Fixtures.SetRestrictions
    {
        public SetRestrictions()
            : base(DriverProvider.New<FirefoxDriver>())
        {
        }
    }
}
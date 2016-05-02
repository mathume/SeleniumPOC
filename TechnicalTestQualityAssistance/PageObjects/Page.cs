using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TechnicalTestQualityAssistance.PageObjects
{
    internal class Page
    {
        public object MainHeader { get; set; }

        public PageMenu Menu { get; private set; }
    }
}

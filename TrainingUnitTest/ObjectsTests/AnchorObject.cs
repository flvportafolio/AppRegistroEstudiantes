using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingUnitTest.Helper;

namespace TrainingUnitTest.ObjectsTests
{
    public class AnchorObject
    {
        public AnchorObject(By locator)
        {
            Locator = locator;
        }

        public void Click()
        {
            DriverHelper.Click(Locator);
        }

        public string GetHref()
        {
            return DriverHelper.GetHref(Locator);
        }

        public bool IsDisplayed => DriverHelper.ElementIsDisplayed(Locator);
        
        private By Locator { get; set; }
    }
}

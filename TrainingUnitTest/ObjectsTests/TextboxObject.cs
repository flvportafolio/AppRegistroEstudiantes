using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using TrainingUnitTest.Helper;

namespace TrainingUnitTest.ObjectsTests
{
    public class TextboxObject
    {
        private By Locator { get; set; }

        public TextboxObject(By locator)
        {
            Locator = locator;
        }

        public void SetText(string text)
        {
            DriverHelper.SetText(Locator, text);
        }
        public bool IsVisible()
        {
            return DriverHelper.GetCssValue(Locator, "visibility") == "visible";
        }

        public bool IsDisplayed => DriverHelper.ElementIsDisplayed(Locator);
    }
}

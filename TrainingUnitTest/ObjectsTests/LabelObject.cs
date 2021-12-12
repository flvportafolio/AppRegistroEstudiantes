using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingUnitTest.Helper;

namespace TrainingUnitTest.ObjectsTests
{
    public class LabelObject
    {
        private By Locator { get; set; }
        public LabelObject(By locator)
        {
            Locator = locator;
        }
        public void Click()
        {
            DriverHelper.Click(Locator);
        }
        public string GetText()
        {
            return DriverHelper.GetAttribute(Locator, "innerHTML");
        }
    }
}

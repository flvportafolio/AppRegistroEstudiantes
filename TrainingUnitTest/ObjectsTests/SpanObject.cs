using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingUnitTest.Helper;

namespace TrainingUnitTest.ObjectsTests
{
    /// <summary>
    /// Esta Clase Representa a un Span Element de HTML
    /// </summary>
    public class SpanObject
    {
        private By Locator { get; set; }

        public SpanObject(By locator)
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

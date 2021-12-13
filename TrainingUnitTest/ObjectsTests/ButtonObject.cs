using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using TrainingUnitTest.Helper;

namespace TrainingUnitTest.ObjectsTests
{
    /// <summary>
    /// Esta Clase Representa a un Button Element de HTML
    /// </summary>
    public class ButtonObject
    {
        public ButtonObject(By locator)
        {
            Locator = locator;
        }

        public void Click()
        {
            DriverHelper.Click(Locator);
        }

        public bool IsDisplayed => DriverHelper.ElementIsDisplayed(Locator);
        private By Locator { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TrainingUnitTest.Helper
{
    class DriverHelper
    {
        public static void SetText(By locator, string text)
        {
            try
            {
                var webElement = Browser.GetDriver().FindElement(locator);
                webElement.SendKeys(text);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void Click(By locator)
        {
            try
            {
                var webElement = Browser.GetDriver().FindElement(locator);
                webElement.Click();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static bool ElementIsDisplayed(By locator, int timeOut = 20)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(Browser.GetDriver(), TimeSpan.FromSeconds(timeOut));
                var element = Browser.GetDriver().FindElement(locator);
                return element.Displayed;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public static string GetHref (By locator) //usar GetAttribute en vez de esta funcion
        {
            try
            {
                var webElement = Browser.GetDriver().FindElement(locator);
                return webElement.GetAttribute("href");
            }
            catch (Exception)
            {

                return "";
            }
        }
        public static string GetAttribute(By locator, string attribute, int timeOut = 20)
        {
            try
            {
                if (ElementIsDisplayed(locator, timeOut))
                {
                    var webElement = Browser.GetDriver().FindElement(locator);
                    return webElement.GetAttribute(attribute);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return null;
        }
        public static string GetCssValue(By locator, string property, int timeOut = 20)
        {
            try
            {
                var webElement = Browser.GetDriver().FindElement(locator);
                return webElement.GetCssValue(property);
            }
            catch (Exception)
            {
                return "";
            }            
        }
    }
}

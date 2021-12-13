using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TrainingUnitTest.Helper
{
    /// <summary>
    /// Representa al Navegador Web Chrome y sus funcionalidades.
    /// </summary>
    public class Browser
    {
        static ConcurrentDictionary<Thread, IWebDriver> drivers = new ConcurrentDictionary<Thread, IWebDriver>();

        public static IWebDriver CreateWebDriver()
        {
            IWebDriver driver;
            ChromeOptions preferences = new ChromeOptions();
            preferences.AddArguments("--start-maximized");
            driver = new ChromeDriver(AppDomain.CurrentDomain.BaseDirectory, preferences);
            drivers.TryAdd(Thread.CurrentThread, driver);

            return driver;
        }

        public static void NavigateTo(string url)
        {
            GetDriver().Navigate().GoToUrl(url);
        }

        public static void CloseBrowser()
        {
            DeleteCookies();
            Close();
            drivers.Clear();
        }

        private static void DeleteCookies()
        {
            GetDriver().Manage().Cookies.DeleteAllCookies();
        }

        private static void Close()
        {
            GetDriver().Quit();
        }

        public static IWebDriver GetDriver()
        {
            IWebDriver selecDriver;
            if (drivers.TryGetValue(Thread.CurrentThread, out selecDriver))
            {
                return selecDriver;
            }
            else
            {
                throw new InvalidCastException("No se puedo obtener el driver");
            }
        }
    }
}

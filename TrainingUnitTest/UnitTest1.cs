using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
namespace TrainingUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestSearchGoogle()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.google.com");
            driver.Manage().Window.Maximize();
            IWebElement txtBuscar = driver.FindElement(By.CssSelector(".gLFyf[title='Buscar']"));
            txtBuscar.SendKeys("Selenium");
            var txtBuscarValue = txtBuscar.GetAttribute("value");
            txtBuscar.Click();
            Assert.IsTrue(txtBuscarValue == "Selemium", "Erro en el input");

        }
    }
}

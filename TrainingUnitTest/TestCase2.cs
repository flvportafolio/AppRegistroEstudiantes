using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TrainingUnitTest
{
    [TestClass]
    public class TestCase2
    {
        [TestMethod]
        public void Test1_VerificarBotonEditar()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost/Alumno");
            driver.Manage().Window.Maximize();
            IWebElement btnEditar = driver.FindElement(By.XPath("//tbody/tr[2]/td[1]/a[@title='Editar']"));
            string expectedURL = btnEditar.GetAttribute("href");
            btnEditar.Click();

            //Assert
            Assert.AreEqual(expectedURL, driver.Url, "Error al redirigir a la interfaz de editar");
            driver.Quit();
        }
        [TestMethod]
        public void Test2_VerificarBotonVer()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost/Alumno");
            driver.Manage().Window.Maximize();
            IWebElement btnVer = driver.FindElement(By.XPath("//tbody/tr[2]/td[2]/a[@title='Ver']"));
            string expectedURL = btnVer.GetAttribute("href");
            btnVer.Click();

            //Assert
            Assert.AreEqual(expectedURL, driver.Url, "Error al redirigir a la interfaz de ver");
            driver.Quit();
        }
        [TestMethod]
        public void Test3_VerificarBotonEliminar()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost/Alumno");
            driver.Manage().Window.Maximize();
            IWebElement btnEliminar = driver.FindElement(By.XPath("//tbody/tr[2]/td[3]/a[@title='Eliminar']"));
            string expectedURL = btnEliminar.GetAttribute("href");
            btnEliminar.Click();

            //Assert
            Assert.AreEqual(expectedURL, driver.Url, "Error al redirigir a la interfaz de eliminar");
            driver.Quit();
        }
    }
}

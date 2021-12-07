using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TrainingUnitTest
{
    [TestClass]
    public class TestCase3
    {
        [TestMethod]
        public void Test1_VerificarValidaciones_Alumno_CamposVacios()
        {
            //Arrange
            string expectedNameMessage = "El campo Nombre es obligatorio.";
            string expectedFechaNacMessage = "El campo Fecha de Nacimiento es obligatorio.";

            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost/Alumno/Create");
            driver.Manage().Window.Maximize();            
            IWebElement botonGuardar = driver.FindElement(By.CssSelector("#btnGuardar"));            
            botonGuardar.Click();

            IWebElement NameMsgValidation = driver.FindElement(By.CssSelector("#Nombre-error"));
            IWebElement FechaNacMsgValidation = driver.FindElement(By.CssSelector("#FechaNacimiento-error"));

            //Assert
            Assert.AreEqual(expectedNameMessage, NameMsgValidation.Text, "Error al mostrar el mensaje de validacion para nombre");
            Assert.AreEqual(expectedFechaNacMessage, FechaNacMsgValidation.Text, "Error al mostrar el mensaje de validacion para fecha de nacimiento");
            driver.Quit();
        }
        [TestMethod]
        public void Test2_VerificarValidaciones_Alumno_Foto()
        {
            //Arrange
            string expectedMessage = "El campo Foto es obligatorio.";

            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost/Alumno/Create");
            driver.Manage().Window.Maximize();
            IWebElement inputNombre = driver.FindElement(By.CssSelector("#Nombre"));
            IWebElement inputFechaNacimiento = driver.FindElement(By.CssSelector("#FechaNacimiento"));
            IWebElement botonGuardar = driver.FindElement(By.CssSelector("#btnGuardar"));
            inputNombre.SendKeys("Roberto Carlos");
            inputFechaNacimiento.SendKeys("12/10/2004");
            botonGuardar.Click();

            //Act 
            IWebElement fotoMsgValidation = driver.FindElement(By.XPath("//span[@data-valmsg-for='Foto']"));

            //Assert
            Assert.AreEqual(expectedMessage, fotoMsgValidation.Text, "Error al mostrar el mensaje de validacion para foto");
            driver.Quit();
        }
    }
}

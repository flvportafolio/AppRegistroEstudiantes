using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using System.Linq;

namespace TrainingUnitTest
{
    [TestClass]
    public class TestCase1
    {
        //[TestMethod]
        /*public void TestSearchGoogle()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.google.com");
            driver.Manage().Window.Maximize();
            IWebElement txtBuscar = driver.FindElement(By.CssSelector(".gLFyf[title='Buscar']"));
            txtBuscar.SendKeys("Selenium");
            var txtBuscarValue = txtBuscar.GetAttribute("value");
            txtBuscar.Click();
            Assert.IsTrue(txtBuscarValue == "Selenium", "Error en el input");

        }*/
        private string nombreAlumno = "Juan Carlos";
        [TestMethod]
        public void Test1_VerificarLabelsFormulario() {
            //Arrange
            IWebDriver driver = new ChromeDriver();
            List<string> formLabels = new List<string>();
            List<string> formLabelsExpected = new List<string> {
                "Nombre", "ApellidoPaterno", "ApellidoMaterno", "Genero","CI",
                "Fecha de Nacimiento", "Lugar de Nacimiento", "Direccion", "Zona", "Telefono",
                "Foto", "Procedencia", "Padre", "Madre"
            };

            //Act            
            driver.Navigate().GoToUrl("http://localhost/Alumno/Create");
            driver.Manage().Window.Maximize();
            for (int i = 1; i <= 3; i++)
            {
                for (int j = 1; j <= 5; j++)
                {
                    if (i == 3 && j >= 5)
                    {
                    }
                    else
                    {
                        IWebElement labelName = driver.FindElement(By.XPath("//div[@class='card-body']/div[@class='form-row'][" + i + "]/div[contains(@class, 'form-group')][" + j + "]/label"));
                        formLabels.Add(labelName.Text);
                    }
                }
            }

            //Assert
            Assert.IsTrue(formLabels.SequenceEqual(formLabelsExpected), "Los labels del formulario no son los esperados o ocurrio algun error");
            driver.Quit();
        }
        [TestMethod]
        public void Test2_VerificarInputsFormulario()
        {
            //Arrange
            IWebDriver driver = new ChromeDriver();
            int counterVisibleItems = 0;
            int expectedVisibleItems = 14;

            //Act
            driver.Navigate().GoToUrl("http://localhost/Alumno/Create");
            driver.Manage().Window.Maximize();
            IList<IWebElement> formsInputs = driver.FindElements(By.CssSelector(@"
                #Nombre, #ApellidoPaterno, #ApellidoMaterno ,#Genero, #CI,
                #FechaNacimiento, #LugarNacimiento, #Direccion, #Zona ,#Telefono,
                #Foto, #Procedencia, #PadreID, #MadreID
            "));
            foreach (IWebElement formItem in formsInputs)
            {
                if (formItem.GetCssValue("visibility") == "visible")
                {
                    counterVisibleItems++;
                }
            }

            //Assert
            Assert.AreEqual(expectedVisibleItems, counterVisibleItems, "Hay");
            driver.Quit();
        }
        [TestMethod]
        public void Test3_InsertarAlumno_CamposRequeridos()
        {
            //Arrange
            string expectedURL = "http://localhost/Alumno";

            //Act
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost/Alumno/Create");
            driver.Manage().Window.Maximize();

            //Registrar Alumno
            IWebElement botonGuardar =  driver.FindElement(By.CssSelector("#btnGuardar"));
            IWebElement inputNombre = driver.FindElement(By.CssSelector("#Nombre"));
            inputNombre.SendKeys(nombreAlumno);
            IWebElement inputFechaNacimiento = driver.FindElement(By.CssSelector("#FechaNacimiento"));
            inputFechaNacimiento.SendKeys("12/10/2002");
            IWebElement UploadImg = driver.FindElement(By.CssSelector("#Foto"));
            UploadImg.SendKeys(@"C:\Users\FABIOPC\Documents\Visual Studio 2019\Proyectos\AppRegistroEstudiantes\AppRegistroEstudiantes\Content\Images\ProfileTest.png");
            botonGuardar.Click();

            //Assert
            Assert.AreEqual(expectedURL, driver.Url, "Error al registrar datos minimos de un Alumno");
            driver.Quit();
        }
        [TestMethod]
        public void Test4_VerificarAlumnoInsertado_CamposRequeridos()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost/Alumno");
            driver.Manage().Window.Maximize();
            IWebElement tdName = driver.FindElement(By.XPath($"//td[contains(text(),'{nombreAlumno}')]"));
            Assert.IsNotNull(tdName, "No se encontro el Alumno que se creo.");
            driver.Quit();
        }
        [TestMethod]
        public void Test5_EliminarAlumnoInsertado_CamposRequeridos() 
        {
            string expectedURL = "http://localhost/Alumno";
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl(expectedURL);
            driver.Manage().Window.Maximize();
            IWebElement btnEliminar = driver.FindElement(By.XPath("//tbody/tr[2]/td[3]/a[@title='Eliminar']"));
            btnEliminar.Click();

            IWebElement btnConfirmarEliminar = driver.FindElement(By.CssSelector("#btnEliminar"));
            btnConfirmarEliminar.Click();
            //Assert
            Assert.AreEqual(expectedURL, driver.Url, "Error al redirigir a la interfaz de listar alumnos");
            driver.Quit();
        }
    }
}

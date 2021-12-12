using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TrainingUnitTest
{
    [TestClass]
    public class TestCase2: UIBase
    {
        [TestMethod]
        public void Test1_VerificarBotonEditar()
        {
            MapperWeb.LaunchBrowser(MapperWeb.IndexAlumno.URL);
            string expectedURL = MapperWeb.IndexAlumno.EditarButton.GetHref();
            MapperWeb.IndexAlumno.EditarButton.Click();

            //Assert
            Assert.AreEqual(expectedURL, MapperWeb.GetCurrentUrl(), "Error al redirigir a la interfaz de editar");
            MapperWeb.IndexAlumno.CloseBrowser();
        }
        [TestMethod]
        public void Test2_VerificarBotonVer()
        {
            MapperWeb.LaunchBrowser(MapperWeb.IndexAlumno.URL);
            string expectedURL = MapperWeb.IndexAlumno.VerButton.GetHref();
            MapperWeb.IndexAlumno.VerButton.Click();

            //Assert
            Assert.AreEqual(expectedURL, MapperWeb.GetCurrentUrl(), "Error al redirigir a la interfaz de ver");
            MapperWeb.IndexAlumno.CloseBrowser();
        }
        [TestMethod]
        public void Test3_VerificarBotonEliminar()
        {
            MapperWeb.LaunchBrowser(MapperWeb.IndexAlumno.URL);
            string expectedURL = MapperWeb.IndexAlumno.EliminarButton.GetHref();
            MapperWeb.IndexAlumno.EliminarButton.Click();            

            //Assert
            Assert.AreEqual(expectedURL, MapperWeb.GetCurrentUrl(), "Error al redirigir a la interfaz de eliminar");
            MapperWeb.IndexAlumno.CloseBrowser();
        }
    }
}

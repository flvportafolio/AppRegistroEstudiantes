using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TrainingUnitTest.UITest
{
    [TestClass]
    public class ActionButtonsAlumnoTest : UIBase
    {
        [TestMethod]
        [TestCategory("Alumno")]
        public void Test1_VerificarBotonEditar()
        {
            MapperWeb.LaunchBrowser(MapperWeb.IndexAlumno.URL);
            string expectedURL = MapperWeb.IndexAlumno.GetEditarButtonInRow("Carlos Perez Gomez").GetHref();
            MapperWeb.IndexAlumno.GetEditarButtonInRow("Carlos Perez Gomez").Click();

            //Assert
            Assert.AreEqual(expectedURL, MapperWeb.GetCurrentUrl(), "Error al redirigir a la interfaz de editar");
            MapperWeb.IndexAlumno.CloseBrowser();
        }
        [TestMethod]
        [TestCategory("Alumno")]
        public void Test2_VerificarBotonVer()
        {
            MapperWeb.LaunchBrowser(MapperWeb.IndexAlumno.URL);
            string expectedURL = MapperWeb.IndexAlumno.GetVerButtonInRow("Carlos Perez Gomez").GetHref();
            MapperWeb.IndexAlumno.GetVerButtonInRow("Carlos Perez Gomez").Click();

            //Assert
            Assert.AreEqual(expectedURL, MapperWeb.GetCurrentUrl(), "Error al redirigir a la interfaz de ver");
            MapperWeb.IndexAlumno.CloseBrowser();
        }
        [TestMethod]
        [TestCategory("Alumno")]
        public void Test3_VerificarBotonEliminar()
        {
            MapperWeb.LaunchBrowser(MapperWeb.IndexAlumno.URL);
            string expectedURL = MapperWeb.IndexAlumno.GetEliminarButtonInRow("Carlos Perez Gomez").GetHref();            
            MapperWeb.IndexAlumno.GetEliminarButtonInRow("Carlos Perez Gomez").Click();

            //Assert
            Assert.AreEqual(expectedURL, MapperWeb.GetCurrentUrl(), "Error al redirigir a la interfaz de eliminar");
            MapperWeb.IndexAlumno.CloseBrowser();
        }
    }
}

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
            MapperWeb.LaunchBrowser(MapperWeb.AlumnoPage.IndexURL);
            string expectedURL = MapperWeb.AlumnoPage.GetEditarButtonInRow("Carlos Perez Gomez").GetHref();
            MapperWeb.AlumnoPage.GetEditarButtonInRow("Carlos Perez Gomez").Click();

            //Assert
            Assert.AreEqual(expectedURL, MapperWeb.GetCurrentUrl(), "Error al redirigir a la interfaz de editar");
            MapperWeb.AlumnoPage.CloseBrowser();
        }
        [TestMethod]
        [TestCategory("Alumno")]
        public void Test2_VerificarBotonVer()
        {
            MapperWeb.LaunchBrowser(MapperWeb.AlumnoPage.IndexURL);
            string expectedURL = MapperWeb.AlumnoPage.GetVerButtonInRow("Carlos Perez Gomez").GetHref();
            MapperWeb.AlumnoPage.GetVerButtonInRow("Carlos Perez Gomez").Click();

            //Assert
            Assert.AreEqual(expectedURL, MapperWeb.GetCurrentUrl(), "Error al redirigir a la interfaz de ver");
            MapperWeb.AlumnoPage.CloseBrowser();
        }
        [TestMethod]
        [TestCategory("Alumno")]
        public void Test3_VerificarBotonEliminar()
        {
            MapperWeb.LaunchBrowser(MapperWeb.AlumnoPage.IndexURL);
            string expectedURL = MapperWeb.AlumnoPage.GetEliminarButtonInRow("Carlos Perez Gomez").GetHref();            
            MapperWeb.AlumnoPage.GetEliminarButtonInRow("Carlos Perez Gomez").Click();

            //Assert
            Assert.AreEqual(expectedURL, MapperWeb.GetCurrentUrl(), "Error al redirigir a la interfaz de eliminar");
            MapperWeb.AlumnoPage.CloseBrowser();
        }
    }
}

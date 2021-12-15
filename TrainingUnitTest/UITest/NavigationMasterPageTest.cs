using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TrainingUnitTest.UITest
{
    [TestClass]
    public class NavigationMasterPageTest : UIBase
    {
        [TestMethod]
        [TestCategory("MasterPage")]
        public void Test_VerificarItemsNavegacion()
        {
            MapperWeb.LaunchBrowser("http://localhost/");

            string expectedInicioURL = MapperWeb.MasterPage.InicioNavItem.GetHref();
            MapperWeb.MasterPage.InicioNavItem.Click();
            Assert.AreEqual(expectedInicioURL, MapperWeb.GetCurrentUrl(), "Error con las Url de Inicio");

            string expectedCursoURL = MapperWeb.MasterPage.CursosNavItem.GetHref();
            MapperWeb.MasterPage.CursosNavItem.Click();
            Assert.AreEqual(expectedCursoURL, MapperWeb.GetCurrentUrl(), "Error con las Url de Curso");

            string expectedTutorURL = MapperWeb.MasterPage.TutoresNavItem.GetHref();
            MapperWeb.MasterPage.TutoresNavItem.Click();
            Assert.AreEqual(expectedTutorURL, MapperWeb.GetCurrentUrl(), "Error con las Url de Tutor");

            string expectedAlumnosURL = MapperWeb.MasterPage.AlumnosNavItem.GetHref();
            MapperWeb.MasterPage.AlumnosNavItem.Click();
            Assert.AreEqual(expectedAlumnosURL, MapperWeb.GetCurrentUrl(), "Error con las Url de Alumno");

            string expectedRegistroURL = MapperWeb.MasterPage.RegistrosNavItem.GetHref();
            MapperWeb.MasterPage.RegistrosNavItem.Click();
            Assert.AreEqual(expectedRegistroURL, MapperWeb.GetCurrentUrl(), "Error con las Url de Registro");

            string expectedHorarioURL = MapperWeb.MasterPage.HorarioNavItem.GetHref();
            MapperWeb.MasterPage.HorarioNavItem.Click();
            Assert.AreEqual(expectedHorarioURL, MapperWeb.GetCurrentUrl(), "Error con las Url de Horario");

            string expectedContactoURL = MapperWeb.MasterPage.ContactoNavItem.GetHref();
            MapperWeb.MasterPage.ContactoNavItem.Click();
            Assert.AreEqual(expectedContactoURL, MapperWeb.GetCurrentUrl(), "Error con las Url de Contacto");

            MapperWeb.MasterPage.CloseBrowser();
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TrainingUnitTest.UITest
{
    [TestClass]
    public class ValidationMessageCreateAlumnoTest : UIBase
    {
        [TestMethod]
        [TestCategory("Alumno")]
        public void Test1_VerificarValidaciones_Alumno_CamposVacios()
        {
            //Arrange
            string expectedNameMessage = "El campo Nombre es obligatorio.";
            string expectedCIMessage = "El campo CI es obligatorio.";
            string expectedFechaNacMessage = "El campo Fecha de Nacimiento es obligatorio.";

            MapperWeb.LaunchBrowser(MapperWeb.AlumnoPage.CreateURL);
            MapperWeb.AlumnoPage.GuardarButton.Click();
            string CurrentTextNameValidation = MapperWeb.AlumnoPage.MsgValidationForName.GetText();
            string CurrentTextCIValidation = MapperWeb.AlumnoPage.MsgValidationForCI.GetText();
            string CurrentTextFechaNacValidation = MapperWeb.AlumnoPage.MsgValidationForFechaNac.GetText();

            //Assert
            Assert.AreEqual(expectedNameMessage, CurrentTextNameValidation, "Error al mostrar el mensaje de validacion para nombre");
            Assert.AreEqual(expectedCIMessage, CurrentTextCIValidation, "Error al mostrar el mensaje de validacion para CI");
            Assert.AreEqual(expectedFechaNacMessage, CurrentTextFechaNacValidation, "Error al mostrar el mensaje de validacion para fecha de nacimiento");
            MapperWeb.AlumnoPage.CloseBrowser();
        }
        [TestMethod]
        [TestCategory("Alumno")]
        public void Test2_VerificarValidaciones_Alumno_Foto()
        {
            //Arrange
            string expectedMessage = "El campo Foto es obligatorio.";

            MapperWeb.LaunchBrowser(MapperWeb.AlumnoPage.CreateURL);
            MapperWeb.AlumnoPage.NombreInput.SetText("Roberto Carlos");
            MapperWeb.AlumnoPage.CIInput.SetText("5012345");
            MapperWeb.AlumnoPage.FechaNacimientoInput.SetText("12/10/2004");
            MapperWeb.AlumnoPage.GuardarButton.Click();                        
            string CurrentTextFotoValidation = MapperWeb.AlumnoPage.MsgValidationForFoto.GetText();

            //Assert
            Assert.AreEqual(expectedMessage, CurrentTextFotoValidation, "Error al mostrar el mensaje de validacion para foto");
            MapperWeb.AlumnoPage.CloseBrowser();
        }
    }
}

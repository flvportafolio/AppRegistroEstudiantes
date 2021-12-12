﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TrainingUnitTest
{
    [TestClass]
    public class TestCase3: UIBase
    {
        [TestMethod]
        public void Test1_VerificarValidaciones_Alumno_CamposVacios()
        {
            //Arrange
            string expectedNameMessage = "El campo Nombre es obligatorio.";
            string expectedFechaNacMessage = "El campo Fecha de Nacimiento es obligatorio.";

            MapperWeb.LaunchBrowser(MapperWeb.CreateAlumno.URL);
            MapperWeb.CreateAlumno.GuardarButton.Click();
            string CurrentTextNameValidation = MapperWeb.CreateAlumno.MsgValidationForName.GetText();
            string CurrentTextFechaNacValidation = MapperWeb.CreateAlumno.MsgValidationForFechaNac.GetText();

            //Assert
            Assert.AreEqual(expectedNameMessage, CurrentTextNameValidation, "Error al mostrar el mensaje de validacion para nombre");
            Assert.AreEqual(expectedFechaNacMessage, CurrentTextFechaNacValidation, "Error al mostrar el mensaje de validacion para fecha de nacimiento");
            MapperWeb.IndexAlumno.CloseBrowser();
        }
        [TestMethod]
        public void Test2_VerificarValidaciones_Alumno_Foto()
        {
            //Arrange
            string expectedMessage = "El campo Foto es obligatorio.";

            MapperWeb.LaunchBrowser(MapperWeb.CreateAlumno.URL);
            MapperWeb.CreateAlumno.NombreInput.SetText("Roberto Carlos");
            MapperWeb.CreateAlumno.FechaNacimientoInput.SetText("12/10/2004");
            MapperWeb.CreateAlumno.GuardarButton.Click();                        
            string CurrentTextFotoValidation = MapperWeb.CreateAlumno.MsgValidationForFoto.GetText();

            //Assert
            Assert.AreEqual(expectedMessage, CurrentTextFotoValidation, "Error al mostrar el mensaje de validacion para foto");
            MapperWeb.IndexAlumno.CloseBrowser();
        }
    }
}

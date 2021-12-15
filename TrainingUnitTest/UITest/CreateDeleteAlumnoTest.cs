using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using System.Linq;

namespace TrainingUnitTest.UITest
{
    [TestClass]    
    public class CreateDeleteAlumnoTest: UIBase
    {
        private string nombreAlumno = "Juan Carlos";

        [TestMethod]
        [TestCategory("Alumno")]
        public void Test1_VerificarLabelsFormulario() {
            //Arrange
            MapperWeb.LaunchBrowser(MapperWeb.AlumnoPage.CreateURL);

            List<string> formLabelsExpected = new List<string> {
                "Nombre", "ApellidoPaterno", "ApellidoMaterno", "Genero","CI",
                "Fecha de Nacimiento", "Lugar de Nacimiento", "Direccion", "Zona", "Telefono",
                "Foto", "Procedencia", "Padre", "Madre"
            };

            //Assert
            Assert.IsTrue(MapperWeb.AlumnoPage.GetformLabelsValueToList().SequenceEqual(formLabelsExpected), "Los labels del formulario no son los esperados o ocurrio algun error");
            MapperWeb.AlumnoPage.CloseBrowser();
        }
        [TestMethod]
        [TestCategory("Alumno")]
        public void Test2_VerificarInputsFormulario()
        {
            MapperWeb.LaunchBrowser(MapperWeb.AlumnoPage.CreateURL);
            //Assert
            Assert.IsTrue(MapperWeb.AlumnoPage.AreAllInputVisible(), "Hay algun input que no se esta visualizando.");
            MapperWeb.AlumnoPage.CloseBrowser();
        }
        [TestMethod]
        [TestCategory("Alumno")]
        public void Test3_InsertarAlumno_CamposRequeridos()
        {
            //Arrange
            string expectedURL = MapperWeb.AlumnoPage.IndexURL;

            MapperWeb.LaunchBrowser(MapperWeb.AlumnoPage.CreateURL);

            //Registrar Alumno
            MapperWeb.AlumnoPage.NombreInput.SetText(nombreAlumno);
            MapperWeb.AlumnoPage.CIInput.SetText("1212121");
            MapperWeb.AlumnoPage.FechaNacimientoInput.SetText("12/10/2002");                        
            MapperWeb.AlumnoPage.FotoInput.SetText(@"C:\Users\FABIOPC\Documents\Visual Studio 2019\Proyectos\AppRegistroEstudiantes\AppRegistroEstudiantes\Content\Images\ProfileTest.png");
            MapperWeb.AlumnoPage.GuardarButton.Click();

            //Assert
            Assert.AreEqual(expectedURL, MapperWeb.GetCurrentUrl(), "Error al registrar datos minimos de un Alumno");
            Assert.IsTrue(MapperWeb.AlumnoPage.ExistRowInTable(nombreAlumno), "No se encontro el Alumno que se creo.");

            MapperWeb.AlumnoPage.GetEliminarButtonInRow(nombreAlumno).Click();
            MapperWeb.AlumnoPage.EliminarButton.Click();
            Assert.AreEqual(MapperWeb.AlumnoPage.IndexURL, MapperWeb.GetCurrentUrl(), "Error al redirigir a la interfaz de listar alumnos");

            MapperWeb.AlumnoPage.CloseBrowser();
        }
    }
}

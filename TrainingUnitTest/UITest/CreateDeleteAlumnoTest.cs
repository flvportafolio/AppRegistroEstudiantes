using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using System.Linq;

namespace TrainingUnitTest
{
    [TestClass]    
    public class CreateDeleteAlumnoTest: UIBase
    {
        private string nombreAlumno = "Juan Carlos";

        [TestMethod]
        [TestCategory("Alumno")]
        public void Test1_VerificarLabelsFormulario() {
            //Arrange
            MapperWeb.LaunchBrowser(MapperWeb.CreateAlumno.URL);

            List<string> formLabelsExpected = new List<string> {
                "Nombre", "ApellidoPaterno", "ApellidoMaterno", "Genero","CI",
                "Fecha de Nacimiento", "Lugar de Nacimiento", "Direccion", "Zona", "Telefono",
                "Foto", "Procedencia", "Padre", "Madre"
            };

            //Assert
            Assert.IsTrue(MapperWeb.CreateAlumno.GetformLabelsValueToList().SequenceEqual(formLabelsExpected), "Los labels del formulario no son los esperados o ocurrio algun error");
            MapperWeb.IndexAlumno.CloseBrowser();
        }
        [TestMethod]
        [TestCategory("Alumno")]
        public void Test2_VerificarInputsFormulario()
        {
            MapperWeb.LaunchBrowser(MapperWeb.CreateAlumno.URL);
            //Assert
            Assert.IsTrue(MapperWeb.CreateAlumno.AreAllInputVisible(), "Hay algun input que no se esta visualizando.");
            MapperWeb.IndexAlumno.CloseBrowser();
        }
        [TestMethod]
        [TestCategory("Alumno")]
        public void Test3_InsertarAlumno_CamposRequeridos()
        {
            //Arrange
            string expectedURL = MapperWeb.IndexAlumno.URL;

            MapperWeb.LaunchBrowser(MapperWeb.CreateAlumno.URL);

            //Registrar Alumno
            MapperWeb.CreateAlumno.NombreInput.SetText(nombreAlumno);
            MapperWeb.CreateAlumno.FechaNacimientoInput.SetText("12/10/2002");                        
            MapperWeb.CreateAlumno.FotoInput.SetText(@"C:\Users\FABIOPC\Documents\Visual Studio 2019\Proyectos\AppRegistroEstudiantes\AppRegistroEstudiantes\Content\Images\ProfileTest.png");            
            MapperWeb.CreateAlumno.GuardarButton.Click();

            //Assert
            Assert.AreEqual(expectedURL, MapperWeb.GetCurrentUrl(), "Error al registrar datos minimos de un Alumno");
            MapperWeb.IndexAlumno.CloseBrowser();
        }
        [TestMethod]
        [TestCategory("Alumno")]
        public void Test4_VerificarAlumnoInsertado_CamposRequeridos()
        {
            MapperWeb.LaunchBrowser(MapperWeb.IndexAlumno.URL);                        
            Assert.IsTrue(MapperWeb.IndexAlumno.ExistRowInTable(nombreAlumno), "No se encontro el Alumno que se creo.");
            MapperWeb.IndexAlumno.CloseBrowser();
        }
        [TestMethod]
        [TestCategory("Alumno")]
        public void Test5_EliminarAlumnoInsertado_CamposRequeridos() 
        {
            MapperWeb.LaunchBrowser(MapperWeb.IndexAlumno.URL);
            MapperWeb.IndexAlumno.GetEliminarButtonInRow(nombreAlumno).Click();
            MapperWeb.DeleteAlumno.EliminarButton.Click();
            //Assert
            Assert.AreEqual(MapperWeb.IndexAlumno.URL, MapperWeb.GetCurrentUrl(), "Error al redirigir a la interfaz de listar alumnos");
            MapperWeb.IndexAlumno.CloseBrowser();
        }
    }
}

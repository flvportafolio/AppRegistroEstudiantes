using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TrainingUnitTest.UITest
{
    [TestClass]
    public class UpdateAlumnoTest : UIBase
    {
        [TestMethod]
        [TestCategory("Alumno")]
        public void Test1_ActualizarAlumno()
        {
            var DatosAlumno = new {
                nombre = "Carla", apellidoPaterno = "Perez", apellidoMaterno = "Soliz",
                genero = "Mujer",
                ci = "1234567",
                fechaNacimiento = "03/03/2003",
                lugarNacimiento = "Beni",
                direccion = "av Riberalta #123",
                zona = "Sur",
                telefono = "76543210",
                foto = @"C:\Users\FABIOPC\Pictures\assets\clases01.jpg",
                procedencia = "Colegio Internacional",
                padre = "Juan Perez Soliz", madre = "Carla Gomez Rivera",
            };
            MapperWeb.LaunchBrowser(MapperWeb.AlumnoPage.IndexURL);
            string expectedURL = MapperWeb.AlumnoPage.GetEditarButtonInRow("Carlos Perez Gomez").GetHref();
            MapperWeb.AlumnoPage.GetEditarButtonInRow("Carlos Perez Gomez").Click();
            Assert.AreEqual(expectedURL, MapperWeb.GetCurrentUrl(), "Error al redirigir a la interfaz de editar");

            //modificar alumno
            MapperWeb.AlumnoPage.ClearFormulario();
            MapperWeb.AlumnoPage.NombreInput.SetText(DatosAlumno.nombre);
            MapperWeb.AlumnoPage.ApellidoPaternoInput.SetText(DatosAlumno.apellidoPaterno);
            MapperWeb.AlumnoPage.ApellidoMaternoInput.SetText(DatosAlumno.apellidoMaterno);
            MapperWeb.AlumnoPage.GeneroSelect.SelectOptionByText(DatosAlumno.genero);
            MapperWeb.AlumnoPage.CIInput.SetText(DatosAlumno.ci);
            MapperWeb.AlumnoPage.FechaNacimientoInput.SetText(DatosAlumno.fechaNacimiento);
            MapperWeb.AlumnoPage.LugarNacimientoInput.SetText(DatosAlumno.lugarNacimiento);
            MapperWeb.AlumnoPage.DireccionInput.SetText(DatosAlumno.direccion);
            MapperWeb.AlumnoPage.ZonaInput.SetText(DatosAlumno.zona);
            MapperWeb.AlumnoPage.TelefonoInput.SetText(DatosAlumno.telefono);
            MapperWeb.AlumnoPage.FotoUpdateInput.SetText(DatosAlumno.foto);
            MapperWeb.AlumnoPage.ProcedenciaInput.SetText(DatosAlumno.procedencia);
            MapperWeb.AlumnoPage.PadreInput.SelectOptionByText(DatosAlumno.padre);
            MapperWeb.AlumnoPage.MadreInput.SelectOptionByText(DatosAlumno.madre);
            MapperWeb.AlumnoPage.ActualizarButton.Click();

            Assert.AreEqual(MapperWeb.AlumnoPage.IndexURL, MapperWeb.GetCurrentUrl(), "Error al redirigir al index de alumno");
            Assert.IsTrue(MapperWeb.AlumnoPage.ExistRowInTable($"{DatosAlumno.nombre} {DatosAlumno.apellidoPaterno} {DatosAlumno.apellidoMaterno}"), "No se encontro el nombre del Alumno que se modifico.");
            Assert.IsTrue(MapperWeb.AlumnoPage.ExistRowInTable(DatosAlumno.ci), "No se encontro el CI del Alumno que se modifico.");
            Assert.IsTrue(MapperWeb.AlumnoPage.ExistRowInTable(DatosAlumno.direccion), "No se encontro la direccion del Alumno que se modifico.");
            Assert.IsTrue(MapperWeb.AlumnoPage.ExistRowInTable(DatosAlumno.telefono), "No se encontro el telefono del Alumno que se modifico.");
            Assert.IsTrue(MapperWeb.AlumnoPage.ExistRowInTable(DatosAlumno.procedencia), "No se encontro la procedencia del Alumno que se modifico.");
            Assert.IsTrue(MapperWeb.AlumnoPage.ExistRowInTable(DatosAlumno.madre), "No se encontro a la madre del Alumno que se modifico.");
            Assert.IsTrue(MapperWeb.AlumnoPage.ExistRowInTable(DatosAlumno.padre), "No se encontro al padre del Alumno que se modifico.");            

            MapperWeb.AlumnoPage.CloseBrowser();
        }
    }
}

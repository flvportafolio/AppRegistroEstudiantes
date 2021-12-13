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
            MapperWeb.LaunchBrowser(MapperWeb.IndexAlumno.URL);
            string expectedURL = MapperWeb.IndexAlumno.GetEditarButtonInRow("Carlos Perez Gomez").GetHref();
            MapperWeb.IndexAlumno.GetEditarButtonInRow("Carlos Perez Gomez").Click();
            Assert.AreEqual(expectedURL, MapperWeb.GetCurrentUrl(), "Error al redirigir a la interfaz de editar");

            //modificar alumno
            MapperWeb.UpdateAlumno.ClearFormulario();
            MapperWeb.UpdateAlumno.NombreInput.SetText(DatosAlumno.nombre);
            MapperWeb.UpdateAlumno.ApellidoPaternoInput.SetText(DatosAlumno.apellidoPaterno);
            MapperWeb.UpdateAlumno.ApellidoMaternoInput.SetText(DatosAlumno.apellidoMaterno);
            MapperWeb.UpdateAlumno.GeneroSelect.SelectOptionByText(DatosAlumno.genero);
            MapperWeb.UpdateAlumno.CIInput.SetText(DatosAlumno.ci);
            MapperWeb.UpdateAlumno.FechaNacimientoInput.SetText(DatosAlumno.fechaNacimiento);
            MapperWeb.UpdateAlumno.LugarNacimientoInput.SetText(DatosAlumno.lugarNacimiento);
            MapperWeb.UpdateAlumno.DireccionInput.SetText(DatosAlumno.direccion);
            MapperWeb.UpdateAlumno.ZonaInput.SetText(DatosAlumno.zona);
            MapperWeb.UpdateAlumno.TelefonoInput.SetText(DatosAlumno.telefono);
            MapperWeb.UpdateAlumno.FotoInput.SetText(DatosAlumno.foto);
            MapperWeb.UpdateAlumno.ProcedenciaInput.SetText(DatosAlumno.procedencia);
            MapperWeb.UpdateAlumno.PadreSelect.SelectOptionByText(DatosAlumno.padre);
            MapperWeb.UpdateAlumno.MadreSelect.SelectOptionByText(DatosAlumno.madre);
            MapperWeb.UpdateAlumno.ActualizarButton.Click();

            Assert.AreEqual(MapperWeb.IndexAlumno.URL, MapperWeb.GetCurrentUrl(), "Error al redirigir al index de alumno");
            Assert.IsTrue(MapperWeb.IndexAlumno.ExistRowInTable($"{DatosAlumno.nombre} {DatosAlumno.apellidoPaterno} {DatosAlumno.apellidoMaterno}"), "No se encontro el nombre del Alumno que se modifico.");
            Assert.IsTrue(MapperWeb.IndexAlumno.ExistRowInTable(DatosAlumno.ci), "No se encontro el CI del Alumno que se modifico.");
            Assert.IsTrue(MapperWeb.IndexAlumno.ExistRowInTable(DatosAlumno.direccion), "No se encontro la direccion del Alumno que se modifico.");
            Assert.IsTrue(MapperWeb.IndexAlumno.ExistRowInTable(DatosAlumno.telefono), "No se encontro el telefono del Alumno que se modifico.");
            Assert.IsTrue(MapperWeb.IndexAlumno.ExistRowInTable(DatosAlumno.procedencia), "No se encontro la procedencia del Alumno que se modifico.");
            Assert.IsTrue(MapperWeb.IndexAlumno.ExistRowInTable(DatosAlumno.madre), "No se encontro a la madre del Alumno que se modifico.");
            Assert.IsTrue(MapperWeb.IndexAlumno.ExistRowInTable(DatosAlumno.padre), "No se encontro al padre del Alumno que se modifico.");            

            MapperWeb.IndexAlumno.CloseBrowser();
        }
    }
}

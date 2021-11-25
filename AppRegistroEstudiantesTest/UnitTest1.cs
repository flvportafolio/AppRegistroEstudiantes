using ClassLibraryFrontendUtils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using PracticaWeb1.Context;
using AppRegistroEstudiantes.Models;

namespace AppRegistroEstudiantesTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod_FrontendUtils_ParseDecimal()
        {
            //Arrange
            string valorMonetario = "123.12"; //falla si es 123,12 porque asume que , es separador de mil
            decimal valorEsperado = 123.12m;

            //Act
            decimal valorActual = FrontendUtils.ParseDecimal(valorMonetario);

            //Assert
            Assert.AreEqual(valorEsperado, valorActual, "Error en la Conversion a Decimal");
        }

        [TestMethod]
        public void TestMethod_FrontendUtils_existPathImage()
        {
            //Arrange
            string rutaImagen = @"C:\Users\FABIOPC\Documents\Visual Studio 2019\Proyectos\AppRegistroEstudiantes\AppRegistroEstudiantes\Content\Images\ProfileTest.png";
            bool valorEsperado = true;

            //Act
            bool valorActual = FrontendUtils.ExistPathImage(rutaImagen);

            //Assert
            Assert.AreEqual(valorEsperado, valorActual, "Error al encontrar la ruta de la imagen");
        }


        [TestMethod]
        public void TestMethod_Students_ExistsRows()
        {
            //Arrange
            SchoolContext db = new SchoolContext();
            bool valorEsperado = true;

            //Act
            Alumno alumno = db.Alumno.FirstOrDefault();
            bool valorActual = alumno != null;

            //Assert
            Assert.AreEqual(valorEsperado, valorActual, "No existe datos en la tabla.");
        }

        [TestMethod]
        public void TestMethod_Registros_Becas_Validas()
        {
            //Arrange
            SchoolContext db = new SchoolContext();
            bool valorEsperado = true;

            //Act
            Registro registro = db.Registro.Where(c1 => c1.EsBecado == false)
                                           .Where(c2 => c2.Beca > 0)
                                           .FirstOrDefault();
            bool valorActual = registro == null;

            //Assert
            Assert.AreEqual(valorEsperado, valorActual, "Hay registros que no deberian tener becas");
        }
        [TestMethod]
        public void TestMethod_Alumnos_Padres_Validos()
        {
            SchoolContext db = new SchoolContext();
            bool valorEsperado = true;

            //Act
            Alumno alumno = db.Alumno.Where(c1 => c1.Padre.Genero == Persona.TipoGenero.Hombre)
                                           .Where(c2 => c2.Madre.Genero == Persona.TipoGenero.Mujer)
                                           .FirstOrDefault();
            bool valorActual = alumno != null;

            //Assert
            Assert.AreEqual(valorEsperado, valorActual, "Hay alumnos con padres de genero incorrecto.");
        }
    }
}

using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingUnitTest.ObjectsTests;

namespace TrainingUnitTest.Mapper.Alumno
{
    /// <summary>
    /// Representa a la pagina Update del modulo Alumno
    /// </summary>
    public class UpdatePage
    {
        public ButtonObject ActualizarButton { get; set; }

        public TextboxObject NombreInput { get; set; }
        public TextboxObject ApellidoPaternoInput { get; set; }
        public TextboxObject ApellidoMaternoInput { get; set; }
        public TextboxObject GeneroSelect { get; set; }
        public TextboxObject CIInput { get; set; }
        public TextboxObject FechaNacimientoInput { get; set; }
        public TextboxObject LugarNacimientoInput { get; set; }
        public TextboxObject DireccionInput { get; set; }
        public TextboxObject ZonaInput { get; set; }
        public TextboxObject TelefonoInput { get; set; }
        public TextboxObject FotoInput { get; set; }
        public TextboxObject ProcedenciaInput { get; set; }
        public TextboxObject PadreSelect { get; set; }
        public TextboxObject MadreSelect { get; set; }

        public UpdatePage()
        {
            ActualizarButton = new ButtonObject(By.CssSelector("#btnActualizar"));

            NombreInput = new TextboxObject(By.CssSelector("#Nombre"));
            ApellidoPaternoInput = new TextboxObject(By.CssSelector("#ApellidoPaterno"));
            ApellidoMaternoInput = new TextboxObject(By.CssSelector("#ApellidoMaterno"));
            GeneroSelect = new TextboxObject(By.CssSelector("#Genero"));
            CIInput = new TextboxObject(By.CssSelector("#CI"));
            FechaNacimientoInput = new TextboxObject(By.CssSelector("#FechaNacimiento"));
            LugarNacimientoInput = new TextboxObject(By.CssSelector("#LugarNacimiento"));
            DireccionInput = new TextboxObject(By.CssSelector("#Direccion"));
            ZonaInput = new TextboxObject(By.CssSelector("#Zona"));
            TelefonoInput = new TextboxObject(By.CssSelector("#Telefono"));
            FotoInput = new TextboxObject(By.CssSelector("#FotoUpdated"));
            ProcedenciaInput = new TextboxObject(By.CssSelector("#Procedencia"));
            PadreSelect = new TextboxObject(By.CssSelector("#PadreID"));
            MadreSelect = new TextboxObject(By.CssSelector("#MadreID"));
        }
        public void ClearFormulario()
        {
            NombreInput.Clear();
            ApellidoPaternoInput.Clear();
            ApellidoMaternoInput.Clear();
            CIInput.Clear();
            FechaNacimientoInput.Clear();
            LugarNacimientoInput.Clear();
            DireccionInput.Clear();
            ZonaInput.Clear();
            TelefonoInput.Clear();
            ProcedenciaInput.Clear();
        }
    }
}

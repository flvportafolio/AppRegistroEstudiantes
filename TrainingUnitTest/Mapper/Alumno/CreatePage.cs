using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingUnitTest.Helper;
using TrainingUnitTest.ObjectsTests;

namespace TrainingUnitTest.Mapper.Alumno
{
    public class CreatePage
    {
        public string URL { get; }
        public ButtonObject GuardarButton { get; set; }
        public LabelObject NombreLabel { get; set; }
        public LabelObject ApellidoPaternoLabel { get; set; }
        public LabelObject ApellidoMaternoLabel { get; set; }
        public LabelObject GeneroLabel { get; set; }
        public LabelObject CILabel { get; set; }
        public LabelObject FechaNacimientoLabel { get; set; }
        public LabelObject LugarNacimientoLabel { get; set; }
        public LabelObject DireccionLabel { get; set; }
        public LabelObject ZonaLabel { get; set; }
        public LabelObject TelefonoLabel { get; set; }
        public LabelObject FotoLabel { get; set; }
        public LabelObject ProcedenciaLabel { get; set; }
        public LabelObject PadreLabel { get; set; }
        public LabelObject MadreLabel { get; set; }

        public TextboxObject NombreInput { get; set; }
        public TextboxObject ApellidoPaternoInput { get; set; }
        public TextboxObject ApellidoMaternoInput { get; set; }
        public TextboxObject GeneroInput { get; set; }
        public TextboxObject CIInput { get; set; }
        public TextboxObject FechaNacimientoInput { get; set; }
        public TextboxObject LugarNacimientoInput { get; set; }
        public TextboxObject DireccionInput { get; set; }
        public TextboxObject ZonaInput { get; set; }
        public TextboxObject TelefonoInput { get; set; }
        public TextboxObject FotoInput { get; set; }
        public TextboxObject ProcedenciaInput { get; set; }
        public TextboxObject PadreInput { get; set; }
        public TextboxObject MadreInput { get; set; }

        public SpanObject MsgValidationForName { get; set; }
        public SpanObject MsgValidationForCI { get; set; }
        public SpanObject MsgValidationForFechaNac { get; set; }
        public SpanObject MsgValidationForFoto { get; set; }

        public CreatePage()
        {
            URL = "http://localhost/Alumno/Create";
            GuardarButton = new ButtonObject(By.CssSelector("#btnGuardar"));

            NombreLabel = new LabelObject(By.XPath("//label[contains(@class, 'control-label') and text() = 'Nombre']"));
            ApellidoPaternoLabel = new LabelObject(By.XPath("//label[contains(@class, 'control-label') and text() = 'ApellidoPaterno']"));
            ApellidoMaternoLabel = new LabelObject(By.XPath("//label[contains(@class, 'control-label') and text() = 'ApellidoMaterno']"));
            GeneroLabel = new LabelObject(By.XPath("//label[contains(@class, 'control-label') and text() = 'Genero']"));
            CILabel = new LabelObject(By.XPath("//label[contains(@class, 'control-label') and text() = 'CI']"));
            FechaNacimientoLabel = new LabelObject(By.XPath("//label[contains(@class, 'control-label') and text() = 'Fecha de Nacimiento']"));
            LugarNacimientoLabel = new LabelObject(By.XPath("//label[contains(@class, 'control-label') and text() = 'Lugar de Nacimiento']"));
            DireccionLabel = new LabelObject(By.XPath("//label[contains(@class, 'control-label') and text() = 'Direccion']"));
            ZonaLabel = new LabelObject(By.XPath("//label[contains(@class, 'control-label') and text() = 'Zona']"));
            TelefonoLabel = new LabelObject(By.XPath("//label[contains(@class, 'control-label') and text() = 'Telefono']"));
            FotoLabel = new LabelObject(By.XPath("//label[contains(@class, 'control-label') and text() = 'Foto']"));
            ProcedenciaLabel = new LabelObject(By.XPath("//label[contains(@class, 'control-label') and text() = 'Procedencia']"));
            PadreLabel = new LabelObject(By.XPath("//label[contains(@class, 'control-label') and text() = 'Padre']"));
            MadreLabel = new LabelObject(By.XPath("//label[contains(@class, 'control-label') and text() = 'Madre']"));

            NombreInput = new TextboxObject(By.CssSelector("#Nombre"));
            ApellidoPaternoInput = new TextboxObject(By.CssSelector("#ApellidoPaterno"));
            ApellidoMaternoInput = new TextboxObject(By.CssSelector("#ApellidoMaterno"));
            GeneroInput = new TextboxObject(By.CssSelector("#Genero"));
            CIInput = new TextboxObject(By.CssSelector("#CI"));
            FechaNacimientoInput = new TextboxObject(By.CssSelector("#FechaNacimiento"));
            LugarNacimientoInput = new TextboxObject(By.CssSelector("#LugarNacimiento"));
            DireccionInput = new TextboxObject(By.CssSelector("#Direccion"));
            ZonaInput = new TextboxObject(By.CssSelector("#Zona"));
            TelefonoInput = new TextboxObject(By.CssSelector("#Telefono"));
            FotoInput = new TextboxObject(By.CssSelector("#Foto"));
            ProcedenciaInput = new TextboxObject(By.CssSelector("#Procedencia"));
            PadreInput = new TextboxObject(By.CssSelector("#PadreID"));
            MadreInput = new TextboxObject(By.CssSelector("#MadreID"));

            MsgValidationForName = new SpanObject(By.CssSelector("#Nombre-error"));
            MsgValidationForCI = new SpanObject(By.CssSelector("#CI-error"));
            MsgValidationForFechaNac = new SpanObject(By.CssSelector("#FechaNacimiento-error"));
            MsgValidationForFoto = new SpanObject(By.XPath("//span[@data-valmsg-for='Foto']"));
        }
        public void CloseBrowser()
        {
            Browser.CloseBrowser();
        }

        public List<string> GetformLabelsValueToList() {
            return new List<string> {
                NombreLabel.GetText(),
                ApellidoPaternoLabel.GetText(),
                ApellidoMaternoLabel.GetText(),
                GeneroLabel.GetText(),
                CILabel.GetText(),
                FechaNacimientoLabel.GetText(),
                LugarNacimientoLabel.GetText(),
                DireccionLabel.GetText(),
                ZonaLabel.GetText(),
                TelefonoLabel.GetText(),
                FotoLabel.GetText(),
                ProcedenciaLabel.GetText(),
                PadreLabel.GetText(),
                MadreLabel.GetText(),
            };
        }
        public bool AreAllInputVisible()
        {
            List <TextboxObject> ListaInputs = new List<TextboxObject> {
                NombreInput,
                ApellidoPaternoInput,
                ApellidoMaternoInput,
                GeneroInput,
                CIInput,
                FechaNacimientoInput,
                LugarNacimientoInput,
                DireccionInput,
                ZonaInput,
                TelefonoInput,
                FotoInput,
                ProcedenciaInput,
                PadreInput,
                MadreInput,
            };
            int counterVisibleItems = 0;            
            foreach (TextboxObject formItem in ListaInputs)
            {
                if (formItem.IsVisible())
                {
                    counterVisibleItems++;
                }
            }
            return counterVisibleItems == ListaInputs.Count();
        }
    }
}

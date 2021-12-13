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
    /// <summary>
    /// Representa a la pagina Index del modulo Alumno
    /// </summary>
    public class IndexPage
    {
        public string URL { get; }

        public IndexPage()
        {
            URL = "http://localhost/Alumno";
        }

        public void CloseBrowser()
        {
            Browser.CloseBrowser();
        }

        public bool ExistRowInTable(string nombreAlumno)
        {
            return Browser.GetDriver().FindElement(By.XPath($"//td[contains(text(),'{nombreAlumno}')]")) != null;
        }
        public AnchorObject GetEditarButtonInRow(string nombreAlumno)
        {
            return new AnchorObject(By.XPath($"//table//td[contains(text(),'{nombreAlumno}')]/..//a[@title='Editar']"));
        }
        public AnchorObject GetVerButtonInRow(string nombreAlumno)
        {
            return new AnchorObject(By.XPath($"//table//td[contains(text(),'{nombreAlumno}')]/..//a[@title='Ver']"));
        }
        public AnchorObject GetEliminarButtonInRow(string nombreAlumno)
        {
            return new AnchorObject(By.XPath($"//table//td[contains(text(),'{nombreAlumno}')]/..//a[@title='Eliminar']"));
        }
    }
}

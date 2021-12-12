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
    public class IndexPage
    {
        public string URL { get; }
        public AnchorObject EditarButton { get; set; }
        public AnchorObject VerButton { get; set; }
        public AnchorObject EliminarButton { get; set; }

        public IndexPage()
        {
            URL = "http://localhost/Alumno";
            EditarButton = new AnchorObject(By.XPath("//tbody/tr[2]/td[1]/a[@title='Editar']"));
            VerButton = new AnchorObject(By.XPath("//tbody/tr[2]/td[2]/a[@title='Ver']"));
            EliminarButton = new AnchorObject(By.XPath("//tbody/tr[2]/td[3]/a[@title='Eliminar']"));
        }

        public void CloseBrowser()
        {
            Browser.CloseBrowser();
        }

        public bool ExistRowInTable(string nombreAlumno)
        {
            return Browser.GetDriver().FindElement(By.XPath($"//td[contains(text(),'{nombreAlumno}')]")) != null;
        }
    }
}

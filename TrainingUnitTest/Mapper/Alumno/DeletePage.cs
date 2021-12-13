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
    /// Representa a la pagina Delete del modulo Alumno
    /// </summary>
    public class DeletePage
    {
        public string URL { get; }
        public ButtonObject EliminarButton { get; set; }

        public DeletePage()
        {
            URL = "http://localhost/Alumno/Delete";
            EliminarButton = new ButtonObject(By.CssSelector("#btnEliminar"));
        }
        public void CloseBrowser()
        {
            Browser.CloseBrowser();
        }
    }
}

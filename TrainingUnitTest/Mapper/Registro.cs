using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingUnitTest.Helper;
using TrainingUnitTest.ObjectsTests;

namespace TrainingUnitTest.Mapper
{
    public class Registro
    {
        public ButtonObject EditarButton { get; set; }

        public Registro()
        {
            EditarButton = new ButtonObject(By.XPath("//tbody/tr[2]/td[1]/a[@title='Editar']"));
        }

        public void CloseBrowser()
        {
            Browser.CloseBrowser();
        }
    }
}

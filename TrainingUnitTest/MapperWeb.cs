using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingUnitTest.Helper;
using TrainingUnitTest.Mapper;

namespace TrainingUnitTest
{
    /// <summary>
    /// Esta Clase Representa al Sitio Web y su conjunto de modulos 
    /// </summary>
    public class MapperWeb
    {
        public MasterPage MasterPage { get; set; }
        public Alumno AlumnoPage { get; set; }
        public Registro RegistroPage { get; set; }

        public MapperWeb()
        {
            AlumnoPage = new Alumno();
            MasterPage = new MasterPage();
        }

        public string GetCurrentUrl()
        {
            return Browser.GetDriver().Url;
        }
        public void LaunchBrowser(string url)
        {
            Browser.CreateWebDriver();
            Browser.NavigateTo(url);
        }
    }
}

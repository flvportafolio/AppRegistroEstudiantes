using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingUnitTest.Helper;

namespace TrainingUnitTest
{
    public class MapperWeb
    {
        public Mapper.Alumno.IndexPage IndexAlumno { get; set; }
        public Mapper.Alumno.CreatePage CreateAlumno { get; set; }
        public Mapper.Alumno.DeletePage DeleteAlumno { get; set; }

        public Mapper.Registro.IndexPage IndexRegistro { get; set; }

        public MapperWeb()
        {
            IndexAlumno = new Mapper.Alumno.IndexPage();
            CreateAlumno = new Mapper.Alumno.CreatePage();
            DeleteAlumno = new Mapper.Alumno.DeletePage();
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

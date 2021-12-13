using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingUnitTest.ObjectsTests;

namespace TrainingUnitTest.Mapper
{
    /// <summary>
    /// Representa a la pagina que hace de Layout Principal para todas las vistas.
    /// </summary>
    public class MasterPage
    {
        public AnchorObject InicioNavItem { get; set; }
        public AnchorObject CursosNavItem { get; set; }
        public AnchorObject TutoresNavItem { get; set; }
        public AnchorObject AlumnosNavItem { get; set; }
        public AnchorObject RegistrosNavItem { get; set; }
        public AnchorObject HorarioNavItem { get; set; }
        public AnchorObject ContactoNavItem { get; set; }

        public MasterPage()
        {
            InicioNavItem = new AnchorObject(By.XPath("//div[@id='navprincipal']/ul/li/a[contains(text(),'Inicio')]"));
            CursosNavItem = new AnchorObject(By.XPath("//div[@id='navprincipal']/ul/li/a[contains(text(),'Cursos')]"));
            TutoresNavItem = new AnchorObject(By.XPath("//div[@id='navprincipal']/ul/li/a[contains(text(),'Tutores')]"));
            AlumnosNavItem = new AnchorObject(By.XPath("//div[@id='navprincipal']/ul/li/a[contains(text(),'Alumnos')]"));
            RegistrosNavItem = new AnchorObject(By.XPath("//div[@id='navprincipal']/ul/li/a[contains(text(),'Registros')]"));
            HorarioNavItem = new AnchorObject(By.XPath("//div[@id='navprincipal']/ul/li/a[contains(text(),'Horario')]"));
            ContactoNavItem = new AnchorObject(By.XPath("//div[@id='navprincipal']/ul/li/a[contains(text(),'Contacto')]"));
        }
    }
}

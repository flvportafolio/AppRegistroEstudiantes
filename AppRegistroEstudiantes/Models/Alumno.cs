using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppRegistroEstudiantes.Models
{
    public class Alumno : Persona
    {
        [Required]
        public string Foto { get; set; }
        public string Procedencia { get; set; }
        public int PadreID { get; set; }
        public int MadreID { get; set; }

        public virtual Tutor Padre { get; set; }
        public virtual Tutor Madre { get; set; }

        public virtual ICollection<Registro> Registro { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AppRegistroEstudiantes.Models
{
    public class Tutor : Persona
    {
        public string Ocupacion { get; set; }

        [ForeignKey("PadreID")]
        public virtual ICollection<Alumno> Padre { get; set; }
        [ForeignKey("MadreID")]
        public virtual ICollection<Alumno> Madre { get; set; }
    }
}
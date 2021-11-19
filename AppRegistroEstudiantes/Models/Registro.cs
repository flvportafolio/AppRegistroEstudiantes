using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AppRegistroEstudiantes.Models
{
    public class Registro
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public decimal Beca { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("Fecha de Inscripción")]
        public DateTime FechaInscripcion { get; set; }
        [DisplayName("Observacion 1")]
        public string Observacion1 { get; set; }
        [DisplayName("Observacion 2")]
        public string Observacion2 { get; set; }
        public bool EsTraspaso { get; set; }
        public bool EsBecado { get; set; }
        public bool EsRepitente { get; set; }
        [Required]
        public int Matricula { get; set; }
        public bool Estado { get; set; }

        public int AlumnoID { get; set; }
        public int CursoID { get; set; }

        public virtual Alumno Alumno { get; set; }
        public virtual Curso Curso { get; set; }
    }
}
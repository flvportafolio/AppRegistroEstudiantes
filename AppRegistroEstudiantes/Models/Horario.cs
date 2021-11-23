using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AppRegistroEstudiantes.Models
{
    public class Horario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Dia { get; set; }
        [DisplayName("Hora Inicio")]
        public string HoraInicio { get; set; }
        [DisplayName("Hora Fin")]
        public string HoraFin { get; set; }
    }
}
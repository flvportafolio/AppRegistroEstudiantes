using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AppRegistroEstudiantes.Models
{
    public abstract class Persona
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }

        public enum TipoGenero { Hombre = 1, Mujer = 2 }
        public TipoGenero Genero { get; set; }

        public string CI { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Fecha de Nacimiento")]
        [Required]
        public DateTime FechaNacimiento { get; set; }
        [DisplayName("Lugar de Nacimiento")]
        public string LugarNacimiento { get; set; }
        public string Direccion { get; set; }
        public string Zona { get; set; }
        public string Telefono { get; set; }

        [NotMapped]
        [DisplayName("Nombre Completo")]
        public string NombreCompleto
        {
            get
            {
                return $"{Nombre} {ApellidoPaterno} {ApellidoMaterno}";
            }
        }
    }
}
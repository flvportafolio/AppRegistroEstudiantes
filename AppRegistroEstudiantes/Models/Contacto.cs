using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AppRegistroEstudiantes.Models
{
    public class Contacto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es Requerido")]
        [StringLength(30)]
        public string Nombre { get; set; }
        
        [StringLength(100)]
        public string Telefono { get; set; }

        [Display(Name = "Correo electrónico")]
        [Required(ErrorMessage = "El correo es Requerido")]
        [DataType(DataType.EmailAddress, ErrorMessage = "El formato del correo es inválido")]
        [StringLength(100)]
        public string Correo { get; set; }

        [StringLength(50)]
        public string Asunto { get; set; }

        [DataType(DataType.MultilineText, ErrorMessage = "El formato es inválido")]
        [Required(ErrorMessage = "El mensaje es Requerido")]
        public string Mensaje { get; set; }
    }
}
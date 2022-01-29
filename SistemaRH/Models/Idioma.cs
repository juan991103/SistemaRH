using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaRH.Models
{
    public class Idioma
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El idioma es requerido")]
        [StringLength(50)]
        [DataType(DataType.Text)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        public String Nombre { get; set; }
        [Required(ErrorMessage = "El Estado debe estar seleccionado")]
        public bool Estado { get; set; }
    }
}

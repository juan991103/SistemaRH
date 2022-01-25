using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaRH.Models
{
    public class Competencia
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "La descripcion es requerida")]
        [StringLength(50)]
        [DataType(DataType.Text)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        public String Descripcion { get; set; }
        [Required(ErrorMessage = "El Estado debe estar seleccionado")]
        public bool Estado{ get; set; }
    }
}

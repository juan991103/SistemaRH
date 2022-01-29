using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaRH.Models
{
    public class Capacitacion
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "La descripcion es requerida")]
        [StringLength(50)]
        [DataType(DataType.Text)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        public String Descripcion { get; set; }
        [Required(ErrorMessage = "El nivel es requerido")]
        [StringLength(50)]
        [DataType(DataType.Text)]
        public String Nivel { get; set; }
        [Required(ErrorMessage = "Fecha requerida")]
        [DataType(DataType.Date)]
        public DateTime Fecha_Desde { get; set; }        
        [Required(ErrorMessage = "Fecha requerida")]
        [DataType(DataType.Date)]
        public DateTime Fecha_Hasta { get; set; }
        [Required(ErrorMessage = "La descripcion es requerida")]
        [StringLength(100)]
        [DataType(DataType.Text)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        public String Institucion { get; set; }
    }
}

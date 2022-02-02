using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaRH.Models
{
    public class Puestos
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(50)]
        [DataType(DataType.Text)]
        public String Nombre { get; set; }
        [StringLength(20)]
        [DataType(DataType.Text)]
        public String Nivel_Riesgo { get; set; }
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:RD$ 0,0.00}", ApplyFormatInEditMode = false)]
        public double Minimo_Salario { get; set; }
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:RD$ 0,0.00}", ApplyFormatInEditMode = false)]
        public double Maximo_Salario { get; set; }
        public bool Estado { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaRH.Models
{
    public class Empleados
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "La cedula es requerida")]
        [StringLength(11)]
        [DataType(DataType.PhoneNumber)]
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Departamento { get; set; }
        [Required(ErrorMessage = "Elige la fecha")]
        public DateTime Fecha_Ingreso { get; set; }
        public string Puesto { get; set; }
        [Required(ErrorMessage = "Rellene el salario")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:RD$ 0,0.00}", ApplyFormatInEditMode = false)]
        public double Salario_Mensual { get; set; }
        public bool Estado { get; set; }
    }
}

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
        [MaxLength(11)]
        public int Cedula { get; set; }
        [Required(ErrorMessage = "Eliga un empleado")]
        public string Nombre { get; set; }
        public string Departamento { get; set; }
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:RD$ 0,0.00}", ApplyFormatInEditMode = false)]
        public DateTime Fecha_Ingreso { get; set; }
        public string Puesto { get; set; }
        public double Salario_Mensual { get; set; }
        public bool Estado { get; set; }
    }
}

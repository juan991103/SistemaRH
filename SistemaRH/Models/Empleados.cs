using Microsoft.AspNetCore.Mvc;
using SistemaRH.Data;
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
        [DisplayFormat(DataFormatString = "{0:0,000-0000000-0}", ApplyFormatInEditMode = false)]
        [RegularExpression(@"00000000000")]
        public string Cedula { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Departamento { get; set; }
        [Required(ErrorMessage = "Elige la fecha")]
        [DataType(DataType.Date)]
        public DateTime Fecha_Ingreso { get; set; }
        [Required]
        public string Puesto { get; set; }
        [Required(ErrorMessage = "Rellene el salario")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:RD$ 0,0.00}", ApplyFormatInEditMode = false)]
        public double Salario_Mensual { get; set; }
        [Required]
        public bool Estado { get; set; }
    }
}

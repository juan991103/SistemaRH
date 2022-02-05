using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaRH.Models
{
    public class Candidatos
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "La cedula es requerida")]
        [StringLength(11)]
        [DataType(DataType.Text)]
        public string Cedula { get; set; }
        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(50)]
        [DataType(DataType.Text)]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Elija el puesto")]
        public string Puesto { get; set; }
        [Required(ErrorMessage = "El departamento es requerido")]
        [StringLength(50)]
        [DataType(DataType.Text)]
        public string Departamento { get; set; }
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:RD$ 0,0.00}", ApplyFormatInEditMode = false)]
        public double Salario { get; set; }
        [Required(ErrorMessage = "Elija la competencia")]
        public string Competencias { get; set; }
        [Required(ErrorMessage = "Elija la capacitacion")]
        public string Capacitacion { get; set; }
        [Required(ErrorMessage = "Coloca los años de experiencia")]
        public int Experiencia_laboral { get; set; }
        [Required(ErrorMessage = "La recomendacion es requerida")]
        [StringLength(50)]
        [DataType(DataType.Text)]
        public string Idioma_dominante { get; set; }
        [Required(ErrorMessage = "El idioma es requerido")]
        [StringLength(50)]
        [DataType(DataType.Text)]
        public string Idioma_secundario { get; set; }
        [Required(ErrorMessage = "El idioma es requerido")]
        [StringLength(50)]
        [DataType(DataType.Text)]
        public string Recomendacion { get; set; }
        [Required(ErrorMessage = "El Estado debe estar seleccionado")]
        public bool Estado { get; set; }
    }
}

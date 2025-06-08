using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoMAUI.Model.Enums;

namespace ProyectoMAUI.Model
{
    [Table("paciente")]
    public class PacienteModel : ModeloBase
    {
        [Required, StringLength(30)]
        public string Nombre { get; set; } = "";

        [Required, StringLength(50, MinimumLength = 2)]
        public string Apellido { get; set; } = "";

        [Required, Range(1, 100)]
        public int Edad { get; set; } = 0;

        [Required, Range(20.0, 300.0)]
        public double Peso { get; set; } = 0.0;

        [Required, Range(50, 250)]
        public int Estatura { get; set; } = 0;

        [Required, RegularExpression(@"^[MF]$")]
        public string Sexo { get; set; } = "";

        [Required]
        public NivelActividad NivelActividad { get; set; }

        public override string ToString() =>
            $"Id:{Id} - {Nombre} {Apellido}";
    }
}

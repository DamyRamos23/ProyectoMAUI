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

        public double CalcularIMC()
        {
            double estaturaMetros = Estatura / 100;
            return Peso / (estaturaMetros * estaturaMetros);
        }
        public double CalcularGrasa()
        {
            double grasa;

            grasa = 1.2 * CalcularIMC() + 0.23 * Edad - 5.4;

            if (Sexo == "M") // si es hombre se toma en cuenta el 10.8
            {
                grasa = grasa - 10.8;
            }

            return grasa;
        }

        public double CalcularPesoIdeal()
        {
            double pesoIdeal;

            if (Sexo == "M")
            {
                pesoIdeal = Estatura - 100 - ((Estatura - 150) / 4);
            }
            else
            {
                pesoIdeal = Estatura - 100 - ((Estatura - 150) / 2.5);
            }

            return pesoIdeal;
        }

        public double CalcularTDEE()
        {
            double brm = CalcularBRM();

            switch (NivelActividad)
            {
                case NivelActividad.RaraVez:
                    brm = brm * 1.2;
                    break;

                case NivelActividad.UnoATresDias:
                    brm = brm * 1.375;
                    break;

                case NivelActividad.TresACincoDias:
                    brm = brm * 1.55;
                    break;

                case NivelActividad.SeisASieteDias:
                    brm = brm * 1.725;
                    break;

                case NivelActividad.MasDeSieteDias:
                    brm = brm * 1.9;
                    break;
            }

            return brm;
        }

        private double CalcularBRM()
        {
            double brm;

            if (Sexo == "M")
            {
                brm = (Estatura * 6.25) + (Peso * 9.99) - (Edad * 4.92) + 5;
            } else {
                brm = (Estatura * 6.25) + (Peso * 9.99) - (Edad * 4.92) - 161;
            }

            return brm;
        }
    }
}

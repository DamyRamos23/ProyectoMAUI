using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using ProyectoMAUI.Model.Enums;

namespace ProyectoMAUI.ViewModel
{
    [QueryProperty(nameof(Id), "Id")]
    public partial class PacienteViewModel : ObservableValidator
    {
        private readonly IPaciente servicioPaciente;

        public ObservableCollection<string> Errores { get; set; } = new();

        [ObservableProperty]
        private string resultado;

        [ObservableProperty]
        private bool isBusy;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsEnabled))]
        private bool isVisible;
        public bool IsEnabled => !IsVisible;

        public ObservableCollection<NivelActividad> OpcionesNivelActividad { get; } = new ObservableCollection<NivelActividad>(Enum.GetValues(typeof(NivelActividad)).Cast<NivelActividad>());

        private int id;
        public int Id
        {
            get => id;
            set
            {
                if (SetProperty(ref id, value))
                {
                    // Ejecuta carga de datos cuando se recibe el parámetro
                    _ = CargarPacienteAsync(id);
                }
            }
        }

        private string nombre;
        [Required(ErrorMessage = "El campo nombre es obligatorio.")]
        [StringLength(30, ErrorMessage = "Máximo 30 caracteres.")]
        public string Nombre
        {
            get => nombre;
            set => SetProperty(ref nombre, value, true);
        }

        private string apellido;
        [Required(ErrorMessage = "El apellido es obligatorio.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Entre 2 y 50 caracteres.")]
        public string Apellido
        {
            get => apellido;
            set => SetProperty(ref apellido, value, true);
        }

        private int edad;
        [Range(1, 120, ErrorMessage = "Edad debe estar entre 1 y 120.")]
        public int Edad
        {
            get => edad;
            set => SetProperty(ref edad, value, true);
        }

        private double peso;
        [Range(20.0, 300.0, ErrorMessage = "Peso debe estar entre 20 y 300 kg.")]
        public double Peso
        {
            get => peso;
            set => SetProperty(ref peso, value, true);
        }

        private int estatura;
        [Range(50, 250, ErrorMessage = "Estatura debe estar entre 50 y 250 cm.")]
        public int Estatura
        {
            get => estatura;
            set => SetProperty(ref estatura, value, true);
        }

        private String sexo;
        [RegularExpression(@"^[MF]$", ErrorMessage = "Solo 'M' o 'F'.")]
        public String Sexo
        {
            get => sexo;
            set => SetProperty(ref sexo, value, true);
        }

        private NivelActividad? nivelActividad;
        [Required(ErrorMessage = "Selecciona un nivel de actividad.")]
        public NivelActividad? NivelActividad
        {
            get => nivelActividad;
            set => SetProperty(ref nivelActividad, value, true);
        }

        public PacienteViewModel()
        {
            servicioPaciente = App.Current.Services.GetService<IPaciente>();
        }

        [RelayCommand]
        public async Task GuardarPaciente()
        {
            IsBusy = true;
            IsVisible = false;
            ValidateAllProperties();

            Errores.Clear();
            GetErrors(nameof(Nombre)).ToList().ForEach(f => Errores.Add("Nombre: " + f.ErrorMessage));
            GetErrors(nameof(Apellido)).ToList().ForEach(f => Errores.Add("Apellido: " + f.ErrorMessage));
            GetErrors(nameof(Edad)).ToList().ForEach(f => Errores.Add("Edad: " + f.ErrorMessage));
            GetErrors(nameof(Peso)).ToList().ForEach(f => Errores.Add("Peso: " + f.ErrorMessage));
            GetErrors(nameof(Estatura)).ToList().ForEach(f => Errores.Add("Estatura: " + f.ErrorMessage));
            GetErrors(nameof(Sexo)).ToList().ForEach(f => Errores.Add("Sexo: " + f.ErrorMessage));
            GetErrors(nameof(NivelActividad)).ToList().ForEach(f => Errores.Add("Nivel Actividad: " + f.ErrorMessage));
            IsBusy = false;
            if (Errores.Count > 0) return;

            IsBusy = true;
            if (Id == 0) 
                Id = await servicioPaciente.InsertPaciente(new PacienteModel() { Nombre = Nombre, Apellido = Apellido, Edad = Edad, Peso = Peso, Estatura = Estatura, Sexo = Sexo, NivelActividad = NivelActividad!.Value });
            else 
                await servicioPaciente.UpdatePaciente(new PacienteModel() { Nombre = Nombre, Apellido = Apellido, Edad = Edad, Peso = Peso, Estatura = Estatura, Sexo = Sexo, NivelActividad = NivelActividad!.Value, Id = Id });

            Resultado = $" Registro id:{Id}";
            IsBusy = false;
            IsVisible = true;

            await Task.Delay(2000);
            await Shell.Current.Navigation.PopToRootAsync();
        }

        private async Task CargarPacienteAsync(int id)
        {
            var paciente = await servicioPaciente.GetById(id);
            if (paciente is null) return;

            Nombre = paciente.Nombre;
            Apellido = paciente.Apellido;
            Edad = paciente.Edad;
            Peso = paciente.Peso;
            Estatura = paciente.Estatura;
            Sexo = paciente.Sexo;
            NivelActividad = paciente.NivelActividad;
        }
    }
}

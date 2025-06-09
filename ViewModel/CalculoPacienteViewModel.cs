using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProyectoMAUI.Model;
using ProyectoMAUI.Servicios;
using Microcharts;
using SkiaSharp;
using ChartEntry = Microcharts.ChartEntry;

namespace ProyectoMAUI.ViewModel
{
    public partial class CalculoPacienteViewModel : ObservableObject
    {
        private readonly IPaciente servicioPaciente;

        public CalculoPacienteViewModel(IPaciente servicioPaciente)
        {
            this.servicioPaciente = servicioPaciente;
            Task.Run(async () => await CargarPacientes());
        }

        public ObservableCollection<PacienteModel> Pacientes { get; } = new();

        [ObservableProperty]
        private PacienteModel pacienteSeleccionado;

        [ObservableProperty]
        private bool isLoading;

        public string ImcTexto => PacienteSeleccionado != null
            ? $"{PacienteSeleccionado.CalcularIMC():F2}"
            : "";

        public string GrasaTexto => PacienteSeleccionado != null
            ? $"{PacienteSeleccionado.CalcularGrasa():F2}%"
            : "";

        public string TdeeTexto => PacienteSeleccionado != null
            ? $"{PacienteSeleccionado.CalcularTDEE()} kcal"
            : "";

        public string PesoIdealTexto => PacienteSeleccionado != null
            ? $"{PacienteSeleccionado.CalcularPesoIdeal():F2} kg"
            : "";

        [RelayCommand]
        public async Task CargarPacientes()
        {
            IsLoading = true;
            Pacientes.Clear();
            var lista = await servicioPaciente.GetAll();
            foreach (var item in lista)
                Pacientes.Add(item);
            IsLoading = false;
        }

        // Cada vez que se seleccione un paciente, forzamos actualización de textos
        partial void OnPacienteSeleccionadoChanged(PacienteModel value)
        {
            if (value is null) return;

            OnPropertyChanged(nameof(ImcTexto));
            OnPropertyChanged(nameof(GrasaTexto));
            OnPropertyChanged(nameof(TdeeTexto));
            OnPropertyChanged(nameof(PesoIdealTexto));
            OnPropertyChanged(nameof(MostrarResultados));
        }

        public bool MostrarResultados => PacienteSeleccionado != null;
    }
}
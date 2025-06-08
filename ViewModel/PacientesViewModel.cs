using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoMAUI.Model.Enums;

namespace ProyectoMAUI.ViewModel
{
    public partial class PacientesViewModel : ObservableObject
    {
        private readonly IPaciente servicioPaciente;
        private readonly IServicioDialogo dialogo;

        public PacientesViewModel(IPaciente servicioPaciente, IServicioDialogo dialogo)
        {
            this.servicioPaciente = servicioPaciente;
            this.dialogo = dialogo;
            Task.Run(async () => await ListarPacientes());
        }

        public ObservableCollection<PacienteModel> Pacientes { get; set; } = new();

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsReady))]
        private bool isLoading;

        [ObservableProperty]
        bool isRefreshing;
        public bool IsReady => !IsLoading;

        [RelayCommand]
        public async Task ListarPacientes()
        {
            IsLoading = true;
            Pacientes.Clear();
            var lista = await servicioPaciente.GetAll();
            foreach (var item in lista) Pacientes.Add(item);
            IsLoading = false;
            IsRefreshing = false;
        }

        [RelayCommand]
        public async Task EditarPaciente(PacienteModel paciente)
        {

            await Shell.Current.GoToAsync($"{nameof(PacienteView)}?Id={paciente.Id}");

        }

        [RelayCommand]
        public async Task EliminarPaciente(PacienteModel paciente)
        {
            IsLoading = true;
            var res = await dialogo.ShowAlertAsync("Eliminar", $"Desea eliminiar el registro {paciente.Id}", "Aceptar", "Cancelar");
            if (!res) return;
            var A = await servicioPaciente.DeletePaciente(paciente);
            await ListarPacientes();

        }

        [RelayCommand]
        public async Task AddNew()
        {
            await Shell.Current.Navigation.PushAsync(new PacienteView(), false);
        }
    }
}

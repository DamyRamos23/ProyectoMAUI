namespace ProyectoMAUI.View;

public partial class CalculoPacienteView : ContentPage
{
	public CalculoPacienteView()
	{
		BindingContext = App.Current.Services.GetRequiredService<CalculoPacienteViewModel>();
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        if (BindingContext is CalculoPacienteViewModel vm)
        {
            await vm.CargarPacientes();
        }
    }
}
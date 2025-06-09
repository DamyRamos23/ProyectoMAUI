namespace ProyectoMAUI.View;

public partial class CalculoPacienteView : ContentPage
{
	public CalculoPacienteView()
	{
		BindingContext = App.Current.Services.GetRequiredService<CalculoPacienteViewModel>();
		InitializeComponent();
	}
}
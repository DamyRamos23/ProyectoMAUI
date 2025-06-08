using ProyectoMAUI.ViewModel;

namespace ProyectoMAUI.View;

public partial class ListadoPacienteView : ContentPage
{
	public ListadoPacienteView()
	{
		BindingContext = App.Current.Services.GetRequiredService<PacientesViewModel>();
		InitializeComponent();
	}
}
using ProyectoMAUI.ViewModel;

namespace ProyectoMAUI.View;

public partial class PacienteView : ContentPage
{
	public PacienteView()
	{
		BindingContext = App.Current.Services.GetRequiredService<PacienteViewModel>();
		InitializeComponent();
	}
}
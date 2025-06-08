using ProyectoMAUI.ViewModel;

namespace ProyectoMAUI.Templates;

public partial class ItemsPacientes : ContentView
{
    private readonly PacientesViewModel viewmodel;
    public ItemsPacientes()
    {
        try
        {
            viewmodel = App.Current.Services.GetService<PacientesViewModel>();
            InitializeComponent();
            //  BindingContext = viewmodel;
        }
        catch (Exception ex)
        {

            throw ex;
        }

    }
}
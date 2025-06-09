namespace ProyectoMAUI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ListadoPacienteView), typeof(ListadoPacienteView));
            Routing.RegisterRoute(nameof(PacienteView), typeof(PacienteView));
            Routing.RegisterRoute(nameof(CalculoPacienteView), typeof(CalculoPacienteView));
        }
    }
}

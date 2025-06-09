using Microsoft.Maui.Controls;
using Microsoft.Extensions.DependencyInjection;
using ProyectoMAUI.ViewModel;
using ProyectoMAUI.Servicios;

namespace ProyectoMAUI
{
    public partial class App : Application
    {
        // Propiedad Current corregida
        public static new App Current => (App)Application.Current;

        // Servicios con inicialización segura
        public IServiceProvider Services { get; }

        public App()
        {
            var serviceCollection = new ServiceCollection();

            Services = ConfigureServices(serviceCollection);

            InitializeComponent();

            MainPage = new AppShell();
        }

        private static IServiceProvider ConfigureServices(IServiceCollection services)
        {
            // Registro de servicios
            services.AddTransient<IPaciente, ServicioPaciente>();
            services.AddTransient<IServicioDialogo, ServicioDialogo>();

            // Registro de ViewModels
            services.AddTransient<PacientesViewModel>();
            services.AddTransient<PacienteViewModel>();
            services.AddTransient<CalculoPacienteViewModel>();

            // Registro de Views
            services.AddTransient<ListadoPacienteView>();
            services.AddTransient<PacienteView>();
            services.AddTransient<CalculoPacienteView>();

            return services.BuildServiceProvider();
        }
    }
}

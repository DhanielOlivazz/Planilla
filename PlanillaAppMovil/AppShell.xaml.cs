using PlanillaAppMovil.Views;
namespace PlanillaAppMovil
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            //rutas de acceso
            Routing.RegisterRoute(nameof(NuevoEmpleadoPage), typeof(NuevoEmpleadoPage));
            Routing.RegisterRoute(nameof(VerEmpleadoPage), typeof(VerEmpleadoPage));
        }
    }
}

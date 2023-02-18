using VehicleApp.Views;
using Xamarin.Forms;

namespace VehicleApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(VehicleManufacturersScreen), typeof(VehicleManufacturersScreen));
        }

    }
}

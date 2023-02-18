using VehicleApp.Data;
using VehicleApp.Data.Manufacturer;
using VehicleApp.Data.Model;
using VehicleApp.DI;
using VehicleApp.Service.Models;
using Xamarin.Forms;

namespace VehicleApp
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            DependencyService.Register<ManufacturerDbMockImpl>();

            var manufacturersDbMock = new ManufacturerDbMockImpl();
            var container = AutofacContainer.Container;

            var modelsDbMock = new ModelDbMockImpl(manufacturersDbMock, container);
            DependencyService.RegisterSingleton<IDatabaseMock<VehicleModel>>(modelsDbMock);
            
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

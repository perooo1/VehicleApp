using Xamarin.Forms;

namespace VehicleApp
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            //should probably start autofac here?
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

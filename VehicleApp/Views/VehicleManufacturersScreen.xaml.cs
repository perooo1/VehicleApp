using VehicleApp.Repository;
using VehicleApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VehicleApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VehicleManufacturersScreen : ContentPage
    {
        private VehicleManufacturersViewModel viewModel;
        public VehicleManufacturersScreen()
        {
            InitializeComponent();

            ManufacturerRepositoryImpl repo = new ManufacturerRepositoryImpl();
            BindingContext = viewModel = new VehicleManufacturersViewModel(repo);
        }

        protected  override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.OnAppearing();
        }
    }
}
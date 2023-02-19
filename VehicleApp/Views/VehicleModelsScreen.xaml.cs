using VehicleApp.Repository;
using VehicleApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VehicleApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class VehicleModelsScreen : ContentPage
	{
		private VehicleModelsViewModel viewModel;
		public VehicleModelsScreen ()
		{
			InitializeComponent ();

			VehicleModelRepositoryImpl modelRepositoryImpl= new VehicleModelRepositoryImpl();
			BindingContext = viewModel = new VehicleModelsViewModel(modelRepositoryImpl);
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.OnAppearing();
        }
    }
}
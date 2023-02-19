using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleApp.Repository;
using VehicleApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VehicleApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ModelDetailsScreen : ContentPage
	{
		private ModelDetailViewModel viewModel;
		public ModelDetailsScreen ()
		{
			InitializeComponent ();

			VehicleModelRepositoryImpl modelRepo= new VehicleModelRepositoryImpl();
			BindingContext = viewModel = new ModelDetailViewModel(modelRepo);
		}
		
    }
}
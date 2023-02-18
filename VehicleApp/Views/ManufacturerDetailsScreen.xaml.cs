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
    public partial class ManufacturerDetailsScreen : ContentPage
    {
        private ManufacturerDetailViewModel viewModel;
        public ManufacturerDetailsScreen()
        {
            InitializeComponent();

            ManufacturerRepositoryImpl manufRepo = new ManufacturerRepositoryImpl();
            VehicleModelRepositoryImpl modelRepo = new VehicleModelRepositoryImpl();

            BindingContext = viewModel = new ManufacturerDetailViewModel(manufRepo, modelRepo);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.OnAppearing();
        }

    }
}
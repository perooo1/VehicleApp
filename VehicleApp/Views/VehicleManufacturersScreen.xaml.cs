using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleApp.DI;
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

            try
            {
                ManufacturerRepositoryImpl repo = new ManufacturerRepositoryImpl();
                BindingContext = viewModel = new VehicleManufacturersViewModel(repo);

            }
            catch (Exception e)
            {
                
                
            }

        }

        protected  override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.OnAppearing();

        }

    }
}
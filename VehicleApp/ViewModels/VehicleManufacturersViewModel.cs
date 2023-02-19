using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using VehicleApp.Repository;
using VehicleApp.Service.Models;
using VehicleApp.Views;
using Xamarin.Forms;

namespace VehicleApp.ViewModels
{
    public class VehicleManufacturersViewModel : BaseViewModel
    {
        private VehicleManufacturer selectedManuf;
        private ManufacturerRepositoryImpl Repository { get; set; }
        public ObservableRangeCollection<VehicleManufacturer> Manufacturers { get; set; }
        public Command LoadManufsCommand { get; }
        public Command<VehicleManufacturer> ManufacturerSelected { get; }


        public VehicleManufacturersViewModel(ManufacturerRepositoryImpl repo)
        {
            Title = "Manufacturers";
            this.Repository= repo;
            Manufacturers = new ObservableRangeCollection<VehicleManufacturer>();
            LoadManufsCommand = new Command(async () => await ExecuteLoadManufsCommand());
            ManufacturerSelected = new Command<VehicleManufacturer>(OnItemSelected);

            Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
        }

        private async Task ExecuteLoadManufsCommand()
        {

            IsBusy = true;

            try
            {
                Manufacturers.Clear();
                var items = await Repository.GetAllItemsAsync(true);
                Manufacturers.ReplaceRange(items);

            }
            catch (Exception e)
            {

            }
            finally
            {
                IsBusy = false;
            }
        }

        public VehicleManufacturer SelectedManuf
        {
            get => selectedManuf;
            set
            {
                SetProperty(ref selectedManuf, value);
                OnItemSelected(value);
            }
        }

        async void OnItemSelected(VehicleManufacturer manuf)
        {
            if (manuf == null)
                return;

            await Shell.Current.GoToAsync($"{nameof(ManufacturerDetailsScreen)}?{nameof(ManufacturerDetailViewModel.ManufId)}={manuf.Id}");
        }

        public async Task OnAppearing()
        {
            IsBusy = true;
            SelectedManuf = null;
            try
            {
                Trace.WriteLine("Test123");
                await ExecuteLoadManufsCommand();
            }
            catch (Exception e)
            {
                var a = 9;

            }
        }

    }
}

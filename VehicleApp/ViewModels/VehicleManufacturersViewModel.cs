using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using VehicleApp.Repository;
using VehicleApp.Service.Models;
using Xamarin.Forms;

namespace VehicleApp.ViewModels
{
    public class VehicleManufacturersViewModel : BaseViewModel
    {
        private ManufacturerRepositoryImpl Repository { get; set; }
        public ObservableRangeCollection<VehicleManufacturer> Manufacturers { get; set; }
        //public ICollection<VehicleManufacturer> Manufacturers { get; set; }
        public Command LoadManufsCommand { get; }

        public VehicleManufacturersViewModel(ManufacturerRepositoryImpl repo)
        {
            this.Repository= repo;
            Manufacturers = new ObservableRangeCollection<VehicleManufacturer>();
            //Manufacturers= new ObservableCollection<VehicleManufacturer>();
            LoadManufsCommand = new Command(async () => await ExecuteLoadManufsCommand());
            Title = "Manufacturers";

            Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
        }

        private async Task ExecuteLoadManufsCommand()
        {

            Manufacturers.Clear();
            var items = await Repository.GetAllItemsAsync(true);
            Manufacturers.ReplaceRange(items);
            /*
            Trace.WriteLine(Manufacturers,"before await: Execute manufs command: Manufacturers");
            var manufs = await Repository.GetAllItemsAsync();
            Trace.WriteLine(manufs, "after await: Execute manufs command: manufs");
            Manufacturers = manufs;
            //Manufacturers = manufs;
            */

        }

        public async Task OnAppearing()
        {
            IsBusy = true;
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

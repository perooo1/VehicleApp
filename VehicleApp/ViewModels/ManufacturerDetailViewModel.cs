using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using VehicleApp.Repository;
using Xamarin.Forms;

namespace VehicleApp.ViewModels
{
    [QueryProperty(nameof(ManufId), nameof(ManufId))]
    public class ManufacturerDetailViewModel : BaseViewModel
    {
        private string manufId;
        private string manufName;
        private string manufAbbrv;
        public string Id { get; set; }

        public ManufacturerRepositoryImpl ManufacturerRepository { get; set; }
        public VehicleModelRepositoryImpl VehicleModelRepository { get; set; }


        public ManufacturerDetailViewModel(ManufacturerRepositoryImpl manufRepo, VehicleModelRepositoryImpl modelRepo)
        {
            Title = "Manufacturer Details";
            ManufacturerRepository = manufRepo;
            VehicleModelRepository= modelRepo;



        }

        public string ManufId
        {
            get { return manufId; }
            set { LoadManufFromRepo(value); }
        }

        public string ManufName
        {
            get { return manufName; }
            set { SetProperty(ref manufName, value); }
        }

        public string ManufAbbrv
        {
            get { return manufAbbrv; }
            set { SetProperty(ref manufAbbrv, value); }
        }

        private async void LoadManufFromRepo(string manufId)
        {
            try
            {
                var manuf = await ManufacturerRepository.GetItemAsync(manufId);
                Id = manuf.Id;
                ManufName = manuf.Name;
                ManufAbbrv= manuf.Abrv;
            }
            catch (Exception)
            {
                Trace.WriteLine("Failed to Load Vehicle manufacturer.");
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            //SelectedV = null;
        }

    }
}

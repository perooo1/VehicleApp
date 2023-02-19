using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using VehicleApp.Repository;
using VehicleApp.Service.Models;
using VehicleApp.Views;
using Xamarin.Forms;

namespace VehicleApp.ViewModels
{
    [QueryProperty(nameof(ManufId), nameof(ManufId))]
    public class ManufacturerDetailViewModel : BaseViewModel
    {
        private VehicleModel selectedModel;
        private string manufId;
        private string manufName;
        private string manufAbbrv;
        public string Id { get; set; }

        public ManufacturerRepositoryImpl ManufacturerRepository { get; set; }
        public VehicleModelRepositoryImpl VehicleModelRepository { get; set; }
        public ObservableRangeCollection<VehicleModel> VehicleModels { get; }
        public Command LoadVehicleModelsCommand { get; }
        public Command<VehicleModel> VehicleModelSelected { get; }

        public ManufacturerDetailViewModel(ManufacturerRepositoryImpl manufRepo, VehicleModelRepositoryImpl modelRepo)
        {
            Title = "Manufacturer Details";
            ManufacturerRepository = manufRepo;
            VehicleModelRepository= modelRepo;
            VehicleModels = new ObservableRangeCollection<VehicleModel>();

            LoadVehicleModelsCommand = new Command(async () => await ExecuteLoadVehicleModelsCommand());
            VehicleModelSelected = new Command<VehicleModel>(OnVehicleModelSelected);

        }

        private async void OnVehicleModelSelected(VehicleModel model)
        {
            if (model == null)
                return;

            await Shell.Current.GoToAsync($"{nameof(ModelDetailsScreen)}?{nameof(ModelDetailViewModel.ModelId)}={model.Id}");
        }

        private async Task ExecuteLoadVehicleModelsCommand()
        {
            IsBusy = true;

            try
            {
                VehicleModels.Clear();
                var models = await VehicleModelRepository.GetAllItemsAsync(true);
                List<VehicleModel> modelsNeeded = new List<VehicleModel>();

                foreach(var model in models)
                {
                    if (model.Abrv == manufAbbrv)
                    {
                        modelsNeeded.Add(model);
                    }
                }
                VehicleModels.ReplaceRange(modelsNeeded);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

      public VehicleModel SelectedModel
        {
            get
            {
                return selectedModel;
            }
            set
            {
                selectedModel = value;
                OnVehicleModelSelected(value);
            }
        }

        public string ManufId
        {
            get { return manufId; }
            set {
                manufId = value;
                LoadManufFromRepo(value);
            }
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
            SelectedModel = null;
        }
    }
}

using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VehicleApp.Repository;
using VehicleApp.Service.Models;
using VehicleApp.Views;
using Xamarin.Forms;

namespace VehicleApp.ViewModels
{
    public class VehicleModelsViewModel : BaseViewModel
    {
        private VehicleModel selectedModel;
        private VehicleModelRepositoryImpl ModelRepository { get; set; }
        public ObservableRangeCollection<VehicleModel> Models { get; set; }
        public Xamarin.Forms.Command LoadModelsCommand { get; }
        public Xamarin.Forms.Command ModelSelected { get; }

        public VehicleModelsViewModel(VehicleModelRepositoryImpl modelRepo)
        {
            Title = "Vehicle Models";
            this.ModelRepository= modelRepo;
            Models = new ObservableRangeCollection<VehicleModel>();
            LoadModelsCommand = new Xamarin.Forms.Command(async () => await ExecuteLoadModelsCommand());
            ModelSelected = new Xamarin.Forms.Command<VehicleModel>(OnModelSelected);

        }

        public VehicleModel SelectedModel
        {
            get { return selectedModel; }
            set 
            {
                SetProperty(ref selectedModel, value);
                OnModelSelected(value);
            }
        }

        async void OnModelSelected(VehicleModel model)
        {
            if (model == null)
                return;
            
            await Shell.Current.GoToAsync($"{nameof(ModelDetailsScreen)}?{nameof(ModelDetailViewModel.ModelId)}={model.Id}");
        }

        private async Task ExecuteLoadModelsCommand()
        {
            IsBusy = true;

            try
            {
                Models.Clear();
                var models = await ModelRepository.GetAllItemsAsync();
                Models.ReplaceRange(models);

            }
            catch (Exception e)
            {

            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedModel = null;
        }

    }
}

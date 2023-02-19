using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using VehicleApp.Repository;
using Xamarin.Forms;

namespace VehicleApp.ViewModels
{
    [QueryProperty(nameof(ModelId), nameof(ModelId))]
    public class ModelDetailViewModel: BaseViewModel
    {
        private string modelId;
        private string modelManufId;
        private string modelName;
        private string modelAbbrv;

        public VehicleModelRepositoryImpl ModelRepository { get; set; }

        public ModelDetailViewModel(VehicleModelRepositoryImpl repo)
        {
            Title = "Vehicle Model";
            this.ModelRepository = repo;
        }

        public string ModelId
        {
            get { return modelId; }
            set
            {
                modelId = value;
                LoadModelFromRepo(value);
            }
        }

        public string ModelManufId
        {
            get { return modelManufId; }
            set { modelManufId = value; }
        }

        public string ModelName
        {
            get { return modelName; }
            set { SetProperty(ref modelName, value); }
        }

        public string ModelAbbrv
        {
            get { return modelAbbrv; }
            set { SetProperty(ref modelAbbrv, value); }
        }

        private async void LoadModelFromRepo(string modelId)
        {
            try
            {
                var model = await ModelRepository.GetItemAsync(modelId);
                ModelManufId = model.ManufacturerId;
                modelName = model.Name;
                modelAbbrv= model.Abrv;
            }
            catch (Exception)
            {
                Trace.WriteLine("Failed to Load Vehicle manufacturer.");
            }
        }
        
    }
}

using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VehicleApp.Data;
using VehicleApp.Data.Manufacturer;
using VehicleApp.Data.Model;
using VehicleApp.Service.Models;

namespace VehicleApp.Repository
{
    public class VehicleModelRepositoryImpl : IDatabaseMock<VehicleModel>
    {
        //These repos should implement interface eg. "IRepository" but since it would have the same methods as IDatabaseMock, I decided to reuse that one.

        private IDatabaseMock<VehicleModel> modelDao; 
        
        public VehicleModelRepositoryImpl(IContainer container)
        {
            modelDao = container.Resolve<ModelDbMockImpl>();
        }

        public Task<bool> AddItemAsync(VehicleModel item)
        {
            return modelDao.AddItemAsync(item);
        }

        public Task<ICollection<VehicleModel>> GetAllItemsAsync()
        {
            return modelDao.GetAllItemsAsync();
        }

        public Task<VehicleModel> GetItemAsync(string id)
        {
            return modelDao.GetItemAsync(id);
        }

        public Task<bool> RemoveItemAsync(VehicleModel item)
        {
            return modelDao.RemoveItemAsync(item);
        }

        public Task<bool> UpdateItemAsync(VehicleModel item)
        {
            return modelDao.UpdateItemAsync(item);
        }
    }
}

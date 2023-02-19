using System.Collections.Generic;
using System.Threading.Tasks;
using VehicleApp.Data;
using VehicleApp.Service.Models;
using Xamarin.Forms;

namespace VehicleApp.Repository
{
    public class VehicleModelRepositoryImpl 
    {
        private IDatabaseMock<VehicleModel> db; 
        
        public VehicleModelRepositoryImpl()
        {
            db = DependencyService.Get<IDatabaseMock<VehicleModel>>();
        }

        public Task<bool> AddItemAsync(VehicleModel item)
        {
            return db.AddItemAsync(item);
        }

        public Task<IEnumerable<VehicleModel>> GetAllItemsAsync(bool forceRefresh = false)
        {
            return db.GetAllItemsAsync(forceRefresh);
        }

        public Task<VehicleModel> GetItemAsync(string id)
        {
            return db.GetItemAsync(id);
        }

        public Task<bool> RemoveItemAsync(VehicleModel item)
        {
            return db.RemoveItemAsync(item);
        }

        public Task<bool> UpdateItemAsync(VehicleModel item)
        {
            return db.UpdateItemAsync(item);
        }
    }
}

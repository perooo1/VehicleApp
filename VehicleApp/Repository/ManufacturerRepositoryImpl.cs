using Autofac;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using VehicleApp.Data;
using VehicleApp.Data.Manufacturer;
using VehicleApp.Service.Models;
using Xamarin.Forms;

namespace VehicleApp.Repository
{
    public class ManufacturerRepositoryImpl
    {
        private IDatabaseMock<VehicleManufacturer> db;

        public ManufacturerRepositoryImpl()
        {
            this.db = DependencyService.Get<IDatabaseMock<VehicleManufacturer>>();
            //this.db = container.Resolve<IDatabaseMock<VehicleManufacturer>>();
        }

        public Task<bool> AddItemAsync(VehicleManufacturer item)
        {
            return db.AddItemAsync(item);
        }

        public Task<IEnumerable<VehicleManufacturer>> GetAllItemsAsync(bool forceRefresh = false)
        {
            Trace.WriteLine("inside repository, inside get all items async");
            Trace.WriteLine(db, "db is:");
            return db.GetAllItemsAsync(forceRefresh);
        }

        public Task<VehicleManufacturer> GetItemAsync(string id)
        {
            return db.GetItemAsync(id);
        }

        public Task<bool> RemoveItemAsync(VehicleManufacturer item)
        {
            return db.RemoveItemAsync(item);
        }

        public Task<bool> UpdateItemAsync(VehicleManufacturer item)
        {
            return db.UpdateItemAsync(item);
        }
    }
}

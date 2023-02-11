using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VehicleApp.Data.Manufacturer;
using VehicleApp.Service.Models;

namespace VehicleApp.Data.Model
{
    public class ModelDbMockImpl : IDatabaseMock<VehicleModel>
    {
        private List<VehicleManufacturer> _manufacturers;
        public readonly List<VehicleModel> items;

        public ModelDbMockImpl(IContainer container)
        {
            var manufacturers = container.Resolve<ManufacturerDbMockImpl>();
            this._manufacturers = manufacturers.GetManufacturers();
            items = PopulateDb();
        }

        /*
        public ModelDbMockImpl(ManufacturerDbMockImpl manufacturersDbMock)
        {
            this._manufacturers = manufacturersDbMock.GetManufacturers();
            items = PopulateDb();
        }
        */
        public Task<bool> AddItemAsync(VehicleModel item)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<VehicleModel>> GetAllItemsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<VehicleModel> GetItemAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveItemAsync(VehicleModel item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateItemAsync(int id)
        {
            throw new NotImplementedException();
        }

        private List<VehicleModel> PopulateDb()
        {
            return new List<VehicleModel>()
            {
                TODO()

            };
        }
    }
}

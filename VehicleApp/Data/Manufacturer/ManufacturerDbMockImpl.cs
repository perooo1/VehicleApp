using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VehicleApp.Service.Models;
using Xamarin.Forms;

namespace VehicleApp.Data.Manufacturer
{
    public class ManufacturerDbMockImpl : IDatabaseMock<VehicleManufacturer> //potencijalno napravit dbObjekt koji je isti kao onaj u domain layeru pa mapirat
    {
        public readonly List<VehicleManufacturer> items;

        public ManufacturerDbMockImpl()
        {
            items = PopulateDb();
        }

        public List<VehicleManufacturer> GetManufacturers()         //used to get manufs synchronously in ModelMockDb for mapping in ctor 
        {
            return items;
        }

        public Task<bool> AddItemAsync(VehicleManufacturer item)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<VehicleManufacturer>> GetAllItemsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<VehicleManufacturer> GetItemAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveItemAsync(VehicleManufacturer item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateItemAsync(int id)
        {
            throw new NotImplementedException();
        }

        private List<VehicleManufacturer> PopulateDb()
        {
            var items = new List<VehicleManufacturer>()
            {
                new VehicleManufacturer { Id = "1", Name = "Auto Union Deutschland Ingolstadt", Abrv="AUDI" },
                new VehicleManufacturer { Id = "2", Name = "Bayerische Motoren Werke", Abrv="BMW" },
                new VehicleManufacturer { Id = "3", Name = "Volkswagen AG", Abrv="VW" },
                new VehicleManufacturer { Id = "4", Name = "Toyota Motor Corp.", Abrv="Toyota" },
                new VehicleManufacturer { Id = "5", Name = "Mercedes Benz AG", Abrv="Mercedes" },
                new VehicleManufacturer { Id = "6", Name = "Ford Motor Co.", Abrv="Ford" },
                new VehicleManufacturer { Id = "7", Name = "Honda", Abrv="Honda" },
                new VehicleManufacturer { Id = "8", Name = "Tesla", Abrv="TSLA" },
            };

            foreach(var item in items)
                item.Id = Guid.NewGuid().ToString();

            return items;
        }
    }
}

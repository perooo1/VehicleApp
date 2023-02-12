using Autofac;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleApp.Data.Manufacturer;
using VehicleApp.Service.Models;
using VehicleApp.Utils;

namespace VehicleApp.Data.Model
{
    public class ModelDbMockImpl : IDatabaseMock<VehicleModel>
    {   
        private List<VehicleManufacturer> _manufacturers;
        private IMapper mapper;
        public readonly List<VehicleModel> items;

        public ModelDbMockImpl(IContainer container)
        {
            var manufacturers = container.Resolve<ManufacturerDbMockImpl>();
            this._manufacturers = manufacturers.GetManufacturers();

            this.mapper = container.Resolve<IMapper>();

            items = PopulateDb();
        }

        /*
        public ModelDbMockImpl(ManufacturerDbMockImpl manufacturersDbMock)
        {
            this._manufacturers = manufacturersDbMock.GetManufacturers();
            items = PopulateDb();
        }
        */
        public async Task<bool> AddItemAsync(VehicleModel item)
        {
            items.Add(item);
            return await Task.FromResult(true);
        }

        public async Task<ICollection<VehicleModel>> GetAllItemsAsync()
        {
            return await Task.FromResult(items);
        }

        public async Task<VehicleModel> GetItemAsync(string id)
        {
            return await Task.FromResult(items.Find(it => it.Id == id));
        }

        public async Task<bool> RemoveItemAsync(VehicleModel item)
        {
            var itemToRemove = items.Find(it => it.Id == item.Id);
            items.Remove(itemToRemove);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(VehicleModel item)
        {
            var old = items.Find(items => items.Id == item.Id);
            int index = items.IndexOf(old);

            items.Remove(old);
            items.Insert(index, item);

            return await Task.FromResult(true);
        }

        private List<VehicleModel> PopulateDb()
        {
            int audiIndex = _manufacturers.FindIndex(it => it.Abrv == VehicleProjectConstants.AUDI);
            int bmwIndex = _manufacturers.FindIndex(it => it.Abrv == VehicleProjectConstants.BMW);
            int vwIndex = _manufacturers.FindIndex(it => it.Abrv == VehicleProjectConstants.VW);
            int toyotaIndex = _manufacturers.FindIndex(it => it.Abrv == VehicleProjectConstants.TOYOTA);
            int mercedesIndex = _manufacturers.FindIndex(it => it.Abrv == VehicleProjectConstants.MERCEDES);
            int fordIndex = _manufacturers.FindIndex(it => it.Abrv == VehicleProjectConstants.FORD);
            int hondaIndex = _manufacturers.FindIndex(it => it.Abrv == VehicleProjectConstants.HONDA);
            int teslaIndex = _manufacturers.FindIndex(it => it.Abrv == VehicleProjectConstants.TESLA);

            var a5 = mapper.Map<VehicleManufacturer, VehicleModel>(_manufacturers.ElementAt(audiIndex));
            var r8 = mapper.Map<VehicleManufacturer, VehicleModel>(_manufacturers.ElementAt(audiIndex));
            a5.Name = VehicleProjectConstants.A5;
            r8.Name = VehicleProjectConstants.R8;

            var x1 = mapper.Map<VehicleManufacturer, VehicleModel>(_manufacturers.ElementAt(bmwIndex));
            var kockica = mapper.Map<VehicleManufacturer, VehicleModel>(_manufacturers.ElementAt(bmwIndex));
            x1.Name = VehicleProjectConstants.X1;
            kockica.Name = VehicleProjectConstants.KOCKICA;

            var tiguan = mapper.Map<VehicleManufacturer, VehicleModel>(_manufacturers.ElementAt(vwIndex));
            var troc = mapper.Map<VehicleManufacturer, VehicleModel>(_manufacturers.ElementAt(vwIndex));
            tiguan.Name = VehicleProjectConstants.TIGUAN;
            troc.Name = VehicleProjectConstants.TROC;
           
            var corolla = mapper.Map<VehicleManufacturer, VehicleModel>(_manufacturers.ElementAt(toyotaIndex));
            var yaris = mapper.Map<VehicleManufacturer, VehicleModel>(_manufacturers.ElementAt(toyotaIndex));
            corolla.Name = VehicleProjectConstants.COROLLA;
            yaris.Name = VehicleProjectConstants.YARIS;
           
            var aClass = mapper.Map<VehicleManufacturer, VehicleModel>(_manufacturers.ElementAt(mercedesIndex));
            var cClass = mapper.Map<VehicleManufacturer, VehicleModel>(_manufacturers.ElementAt(mercedesIndex));
            aClass.Name = VehicleProjectConstants.ACLASS;
            cClass.Name = VehicleProjectConstants.CCLASS;
            
            var focus = mapper.Map<VehicleManufacturer, VehicleModel>(_manufacturers.ElementAt(fordIndex));
            var fiesta = mapper.Map<VehicleManufacturer, VehicleModel>(_manufacturers.ElementAt(fordIndex));
            focus.Name = VehicleProjectConstants.FOCUS;
            fiesta.Name = VehicleProjectConstants.FIESTA;
           
            var accord = mapper.Map<VehicleManufacturer, VehicleModel>(_manufacturers.ElementAt(hondaIndex));
            var civic = mapper.Map<VehicleManufacturer, VehicleModel>(_manufacturers.ElementAt(hondaIndex));
            accord.Name = VehicleProjectConstants.HONDACCORD;
            civic.Name = VehicleProjectConstants.HONDACIVIC;

            var modelS = mapper.Map<VehicleManufacturer, VehicleModel>(_manufacturers.ElementAt(teslaIndex));
            var model3 = mapper.Map<VehicleManufacturer, VehicleModel>(_manufacturers.ElementAt(teslaIndex));
            modelS.Name = VehicleProjectConstants.MODELS;
            model3.Name = VehicleProjectConstants.MODEL3;

            var vehicles = new List<VehicleModel>()
            {
                a5,r8,x1,kockica,tiguan,troc,corolla,yaris,aClass,cClass,focus,fiesta,accord, civic, modelS, model3
            };

            foreach (var v in vehicles)
                v.Id = Guid.NewGuid().ToString();

            return vehicles;
        }
    }
}

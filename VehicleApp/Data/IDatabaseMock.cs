using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace VehicleApp.Data
{
    public interface IDatabaseMock<T>
    {
        Task<bool> AddItemAsync(T item);
        Task<ICollection<T>> GetAllItems();
        Task<T> GetItemAsync(int id);
        Task<bool> UpdateItemAsync(int id);
        Task<bool> RemoveItemAsync(T item);
    }
}

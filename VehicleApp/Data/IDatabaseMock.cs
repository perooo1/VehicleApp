using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace VehicleApp.Data
{
    public interface IDatabaseMock<T>
    {
        Task<bool> AddItemAsync(T item);
        Task<ICollection<T>> GetAllItemsAsync();
        Task<T> GetItemAsync(string id);
        Task<bool> UpdateItemAsync(T item);
        Task<bool> RemoveItemAsync(T item);
    }
}

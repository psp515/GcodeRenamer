using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GcodeRenamer.Interfaces
{
    public interface IService<Item>
    {
        Task AddItemAsync(Item item);
        Task DeleteAllAsync();
        Task DeleteItemAsync(int id);
        Task<Item> GetItemAsync(int id);
        Task<IEnumerable<Item>> GetItemsAsync();
        Task UpdateItemAsync(Item item);
    }
}

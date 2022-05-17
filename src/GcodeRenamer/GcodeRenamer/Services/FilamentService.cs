using GcodeRenamer.Interfaces;
using GcodeRenamer.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GcodeRenamer.Services
{
    public class FilamentService : BaseService, IService<FilamentType>
    {
        const string dbName = "routes";

        public async Task AddItemAsync(FilamentType item)
        {
            await ConnectToDatabase<FilamentType>(dbName);

            if (item==null)
                return;

            await db.InsertAsync(item);
        }

        public async Task DeleteAllAsync()
        {
            await ConnectToDatabase<FilamentType>(dbName);
            await db.DropTableAsync<FilamentType>();
        }

        public async Task DeleteItemAsync(int id)
        {
            if (id == null)
                return;

            await ConnectToDatabase<FilamentType>(dbName);
            await db.DeleteAsync<FilamentType>(id);
        }

        public async Task<FilamentType> GetItemAsync(int id)
        {
            if (id == null)
                return null;

            await ConnectToDatabase<FilamentType>(dbName);
            return await db.Table<FilamentType>().FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<FilamentType>> GetItemsAsync()
        {
            await ConnectToDatabase<FilamentType>(dbName);
            return await db.Table<FilamentType>().ToListAsync();
        }

        public async Task UpdateItemAsync(FilamentType item)
        {
            if (item.Id == null)
                return;

            await ConnectToDatabase<FilamentType>(dbName);
            await db.UpdateAsync(item);
        }
    }
}

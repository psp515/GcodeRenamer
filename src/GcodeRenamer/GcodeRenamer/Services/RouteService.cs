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
    public class RouteService : BaseService, IService<DirectoryPath>
    {
        const string dbName = "routes";

        public async Task AddItemAsync(DirectoryPath item)
        {
            if (item==null)
                return;

            await ConnectToDatabase<DirectoryPath>(dbName);
            await db.InsertAsync(item);
        }

        public async Task DeleteAllAsync()
        {
            await ConnectToDatabase<DirectoryPath>(dbName);
            await db.DropTableAsync<DirectoryPath>();
        }

        public async Task DeleteItemAsync(int id)
        {
            await ConnectToDatabase<DirectoryPath>(dbName);
            await db.DeleteAsync<DirectoryPath>(id);
        }

        public async Task<DirectoryPath> GetItemAsync(int id)
        {
            await ConnectToDatabase<DirectoryPath>(dbName);
            return await db.Table<DirectoryPath>().FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<DirectoryPath>> GetItemsAsync()
        {
            await ConnectToDatabase<DirectoryPath>(dbName);
            return await db.Table<DirectoryPath>().ToListAsync();
        }

        public async Task UpdateItemAsync(DirectoryPath item)
        {
            await ConnectToDatabase<DirectoryPath>(dbName);
            await db.UpdateAsync(item);
        }
    }
}

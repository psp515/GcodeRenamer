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
    //TODO Inicjalizacja jak Transient
    public class FilamentService : IService<DirectoryPath>
    {
        const string dbName = "routes";
        SQLiteAsyncConnection db;

        public FilamentService()
        {
            Task.Run(() => {
                if (db == null)
                {
                    db = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, dbName));
                    await db.CreateTableAsync<DirectoryPath>();
                }
            });
        }

        public async Task AddItemAsync(DirectoryPath item)
        {
            if (item==null)
                return;

            await db.InsertAsync(item);
        }

        public async Task DeleteAllAsync()
        {
            await db.DropTableAsync<DirectoryPath>();
        }

        public async Task DeleteItemAsync(int id)
        {
            if (id == null)
                return;
                
            await db.DeleteAsync<DirectoryPath>(id);
        }

        public async Task<DirectoryPath> GetItemAsync(int id)
        {
            return await db.Table<DirectoryPath>().FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<DirectoryPath>> GetItemsAsync()
        {
            return await db.Table<DirectoryPath>().ToListAsync();
        }

        public async Task UpdateItemAsync(DirectoryPath item)
        {
            if (item.Id == null)
                return;

            await db.UpdateAsync(item);
        }
    }
}

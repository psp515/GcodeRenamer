using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GcodeRenamer.Services
{
    public abstract class BaseService
    {
        protected SQLiteAsyncConnection db;
        protected async Task ConnectToDatabase<Item>(string dbName) where Item : new()
        {
            if (db != null)
                return;

            db = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, dbName));
            await db.CreateTableAsync<Item>();
        }
    }
}

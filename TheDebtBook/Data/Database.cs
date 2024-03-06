using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheDebtBook.Models;
using TheDebtBook.Pages;

namespace TheDebtBook.Data
{
    internal class Database
    {
        private readonly SQLiteAsyncConnection _connection;

        public Database()
        {
            var dataDir = FileSystem.AppDataDirectory;
            var databasePath = Path.Combine(dataDir, "TheDebtBook.db");
            string _dbEncryptionKey = SecureStorage.GetAsync("dbKey").Result;
            
            if (string.IsNullOrEmpty(_dbEncryptionKey))
            {
                Guid g = new Guid();
                _dbEncryptionKey = g.ToString();
                SecureStorage.SetAsync("dbKey", _dbEncryptionKey);
            }
            
            var dbOptions = new SQLiteConnectionString(databasePath, true);
            _connection = new SQLiteAsyncConnection(dbOptions);
            
            _ = Initialise();
        }


        // Laver en ny "Debtor" i databasen
        private async Task Initialise()
        {
            await _connection.CreateTableAsync<Debtor>();
        }

        public async Task<List<Debtor>> GetDebtors()
        {
            return await _connection.Table<Debtor>().ToListAsync();
        }

        public async Task<Debtor> GetName(string name)
        {
            var query = _connection.Table<Debtor>().Where(t => t.Name == name);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<double> AddValue(Debtor value)
        {
            return await _connection.InsertAsync(value);
        }

        public async Task<int> DeleteDebtor(Debtor debtor)
        {
            return await _connection.DeleteAsync(debtor);
        }

        public async Task<int> UpdateDebtorList(Debtor debtor)
        {
            return await _connection.UpdateAsync(debtor);
        }
    }
}

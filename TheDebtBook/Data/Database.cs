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
            var dataDirectory = FileSystem.AppDataDirectory;
            var databasePath = Path.Combine(dataDirectory, "TheDebtBook.db");

            Directory.CreateDirectory(dataDirectory);

            var dbOptions = new SQLiteConnectionString(databasePath, true);
            _connection = new SQLiteAsyncConnection(dbOptions);
            
            _ = Initialise();
        }


        // Laver en ny "Debtor" i databasen
        private async Task Initialise()
        {
            await _connection.CreateTableAsync<Debtor>();
            await _connection.CreateTableAsync<Values>();
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

        public async Task<Debtor> GetDebtorID(int Debtorid)
        {
            var query = _connection.Table<Debtor>().Where(t => t.Id == Debtorid);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Values> GetValue(int valueid)
        {
            var query = _connection.Table<Values>().Where(t => t.ValueId == valueid);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<double> AddDebtor(Debtor debtor)
        {
            return await _connection.InsertAsync(debtor);
        }

        public async Task<double> AddValue(Values value)
        {
            return await _connection.InsertAsync(value);
        }

        public async Task<int> DeleteDebtor(Debtor debtor)
        {
            return await _connection.DeleteAsync(debtor);
        }

        public async Task<int> DeleteValue(Values value)
        {
            return await _connection.DeleteAsync(value);
        }


        public async Task<int> UpdateDebtorList(Debtor debtor)
        {
            return await _connection.UpdateAsync(debtor);
        }

        public async Task<int> UpdateValuesList(Values value)
        {
            return await _connection.UpdateAsync(value);
        }

        public async Task<List<Values>> GetAccumulatedValues(int id)
        {
            var query = _connection.Table<Values>().Where(t => t.DebtorId == id);
            return await query.ToListAsync();
        }
    }
}

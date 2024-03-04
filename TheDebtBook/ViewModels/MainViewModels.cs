using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TheDebtBook.Data;
using TheDebtBook.Models;

namespace TheDebtBook.ViewModels
{
    class MainViewModels : INotifyPropertyChanged
    {
        public MainViewModels()
        {
            _database = new Database();
            AddDebtorCommand = new Command(async () => await AddValueMethod());
            DeleteDebtorCommand = new Command<Debtor>(async (debtor) => await DeleteDebtor(debtor));
            _ = Initialize();
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public void RaisePropertyChanged(params string[] properties)
        {
            foreach (var propertyName in properties)
            {
                PropertyChanged?.Invoke(this, new
                PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

        public ObservableCollection<Debtor> Debtor { get; set; } = new();
        public ICommand AddDebtorCommand {get;set; }
        public string NewName { get; set; } = string.Empty;
        public double AddValue { get; set; } = 0;
        public DateTime NewDate { get; set; } = DateTime.Now;
        public ICommand DeleteDebtorCommand { get; set; }
        private readonly Database _database;

        #region Methods
        private async Task Initialize()
        {
            var debtors = await _database.GetDebtors();
            foreach (var debtor in debtors)
            {
                Debtor.Add(debtor);
            }
        }

        // Main metode - adder new debtor og adder (første) value
        public async Task AddValueMethod()
        {
            var debtor = new Debtor
            {
                Date = NewDate,
                Name = NewName,
                Value = AddValue
            };
            var inserted = await _database.AddValue(debtor);
            if (inserted != 0)
            {
                Debtor.Add(debtor);
                NewName = String.Empty;
                NewDate = DateTime.Now;
                AddValue = 0;
                RaisePropertyChanged(nameof(NewName), nameof(NewDate), nameof(AddValue));
            }
        }

        public async Task DeleteDebtor(Debtor debtor)
        {
            var deleted = await _database.DeleteDebtor(debtor);
            if (deleted != 0)
            {
                Debtor?.Remove(debtor);
            }
        }

        #endregion Methods
    }
}

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
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace TheDebtBook.ViewModels
{
    public partial class MainViewModels : ObservableObject
    {
        private readonly Database _database = new Database();

        [ObservableProperty] public Debtor? _debtor;

        [ObservableProperty] public Values? _values;

        [ObservableProperty] public int? debitvalue;

        [ObservableProperty] public DateTime? date;

        [RelayCommand]
        public void AddValue()
        {
            if (Debtor == null)
            {
                return;
            }

            var values = new Values()
            {
                Value = debitvalue ?? 0,
                Date = date ?? DateTime.Now,
                DebtorId = Debtor.Id

            };

            AddValueAsync(values);
            UpdateAccumulatedValuesAsync(values.ValueId);
        }

        [RelayCommand]
        public void LoadData()
        {
            if (_debtor == null)
            {
                return;
            }
            LoadDataAsync(_debtor.Id);
        }

        public MainViewModels(int debtorID)
        {
            LoadDataAsync(debtorID);
        }

        private async void LoadDataAsync(int debtorID)
        {
            var debtorDatabase = await _database.GetDebtorID(debtorID);
            var Debtor = debtorDatabase;
            var valuesDatabase = await _database.GetAccumulatedValues(debtorID);
            var Values = new List<Values>(valuesDatabase);
        }

        private async void AddValueAsync(Values values)
        {
            await _database.AddValue(values);
            LoadDataAsync(values.DebtorId);
        }

        private async void UpdateAccumulatedValuesAsync(int debtorid)
        {
            var valuesDatabase = await _database.GetAccumulatedValues(debtorid);
            var accumulatedValues = valuesDatabase.Sum(x => x.Value);
            var debtorDatabase = await _database.GetDebtorID(debtorid);
            debtorDatabase.AccumulatedValues = accumulatedValues;
            await _database.UpdateDebtorList(debtorDatabase);
            Debtor = debtorDatabase;
        }


    }
}

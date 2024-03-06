using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheDebtBook.Data;
using TheDebtBook.Models;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using TheDebtBook.Pages;

namespace TheDebtBook.ViewModels
{
    public partial class ValuesListModelView : ObservableObject
    {
        private readonly Database _database = new Database();
        private INavigation _navigation;

        [ObservableProperty] public List<Debtor> _debtors;

        [RelayCommand]
        public void LoadData()
        {
            LoadDataAsync();
        }

        [RelayCommand]
        public void ViewDebtor(int debtorId)
        {
            if (debtorId == 0)
            {
                return;
            }

            _navigation.PushAsync(new MainPage());
        }

        public ValuesListModelView(INavigation navigation)
        {
            _navigation = navigation;
            LoadDataAsync();
        }

        private async void LoadDataAsync()
        {
            var debtorDatabase = await _database.GetDebtors();
            Debtors = new List<Debtor>(debtorDatabase);
        }






    }
}

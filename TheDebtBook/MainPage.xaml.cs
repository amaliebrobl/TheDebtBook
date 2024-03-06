using TheDebtBook.ViewModels;
using TheDebtBook.Pages;

namespace TheDebtBook
{
    public partial class MainPage : ContentPage
    {
        //int count = 0;

        public MainPage()
        {
            InitializeComponent();
            
        }

        private void AddButtonClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddDebtors());
        }

        //private async void OpenAddDebtors(object parameter)
        //{
        //    await Shell.Current.GoToAsync("//addDebtors");
        //}

        //private async void OpenRegisteredList(object parameter)
        //{
        //    await Shell.Current.GoToAsync("//registeredList");
        //}

        //private void OnCounterClicked(object sender, EventArgs e)
        //{
        //    count++;

        //    if (count == 1)
        //        CounterBtn.Text = $"Clicked {count} time";
        //    else
        //        CounterBtn.Text = $"Clicked {count} times";

        //    SemanticScreenReader.Announce(CounterBtn.Text);
        //}
    }

}

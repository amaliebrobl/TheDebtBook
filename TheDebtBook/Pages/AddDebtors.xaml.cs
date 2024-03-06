using TheDebtBook.ViewModels;

namespace TheDebtBook.Pages;

public partial class AddDebtors : ContentPage
{
    AddDebtorViewModel viewModel = new AddDebtorViewModel();
	public AddDebtors()
	{
		InitializeComponent();
        BindingContext = viewModel; // S�tter BindingContext til en instans af MainViewModels
    }

    //private async void AddButtonClicked(object sender, EventArgs e)
    //{
    //    if (BindingContext is MainViewModels viewModel)
    //    {
    //        await viewModel.AddValueMethod(); // Kalder AddValueMethod fra MainViewModels
    //        await Navigation.PopAsync(); // G�r tilbage til hovedsiden (Main-page)
    //    }
    //}

    //// G�r tilbage til Main() page n�r der trykkes 'cancel'
    private void CancelButtonClicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
}
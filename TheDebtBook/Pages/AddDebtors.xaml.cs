using TheDebtBook.ViewModels;

namespace TheDebtBook.Pages;

public partial class AddDebtors : ContentPage
{
    AddDebtorViewModel viewModel = new AddDebtorViewModel();
	public AddDebtors()
	{
		InitializeComponent();
        BindingContext = viewModel; // Sætter BindingContext til en instans af MainViewModels
    }

    //private async void AddButtonClicked(object sender, EventArgs e)
    //{
    //    if (BindingContext is MainViewModels viewModel)
    //    {
    //        await viewModel.AddValueMethod(); // Kalder AddValueMethod fra MainViewModels
    //        await Navigation.PopAsync(); // Går tilbage til hovedsiden (Main-page)
    //    }
    //}

    //// Går tilbage til Main() page når der trykkes 'cancel'
    private void CancelButtonClicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
}
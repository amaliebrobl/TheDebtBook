using TheDebtBook.ViewModels;

namespace TheDebtBook.Pages;

public partial class RegisteredList : ContentPage
{
    ValuesListModelView _modelView;
	public RegisteredList(INavigation navigaton)
    {
        _modelView = new ValuesListModelView(navigaton);
		InitializeComponent();
        BindingContext = _modelView;
        
	}


    private void CloseButtonClicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
}
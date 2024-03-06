namespace TheDebtBook.Pages;

public partial class RegisteredList : ContentPage
{
	public RegisteredList(int Id)
	{
		InitializeComponent();
	}


    private void CloseButtonClicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
}
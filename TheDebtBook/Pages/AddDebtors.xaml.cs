namespace TheDebtBook.Pages;

public partial class AddDebtors : ContentPage
{
	public AddDebtors()
	{
		InitializeComponent();
	}

    private void CancelButtonClicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
}
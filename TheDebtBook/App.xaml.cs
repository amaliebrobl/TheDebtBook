using TheDebtBook.Pages;

namespace TheDebtBook;


public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new NavigationPage(new MainPage());
	}
}
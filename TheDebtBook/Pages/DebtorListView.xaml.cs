using TheDebtBook.ViewModels;

namespace TheDebtBook.Pages;

public partial class DebtorListView : ContentView
{
    private ValuesListModelView _listModelView;
	public DebtorListView(INavigation navigation)
	{
		_listModelView = new ValuesListModelView(navigation);
		InitializeComponent();
		BindingContext = _listModelView;
	}
}
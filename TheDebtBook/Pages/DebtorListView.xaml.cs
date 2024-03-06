using TheDebtBook.ViewModels;

namespace TheDebtBook.Pages;

public partial class DebtorListView : ContentView
{
    ValuesListModelView _viewModel;

    public DebtorListView(INavigation navigation)
    {

        _viewModel = new ValuesListModelView(navigation);
        InitializeComponent();
        BindingContext = _viewModel;

    }
}
using ec.com.naturisa.mobile.feedcontrol.Features.Inventory.ViewModels;

namespace ec.com.naturisa.mobile.feedcontrol.Features.Inventory.Views;

public partial class InventoryWallMoveOneStepView : ContentPage
{
	public InventoryWallMoveOneStepView(InventoryWallMoveOneStepViewModel inventoryWallMoveOneStepViewModel)
	{
		InitializeComponent();
		BindingContext = inventoryWallMoveOneStepViewModel;
    }
}
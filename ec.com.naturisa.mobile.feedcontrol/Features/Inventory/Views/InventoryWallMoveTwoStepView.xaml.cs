using ec.com.naturisa.mobile.feedcontrol.Features.Inventory.ViewModels;

namespace ec.com.naturisa.mobile.feedcontrol.Features.Inventory.Views;

public partial class InventoryWallMoveTwoStepView : ContentPage
{
	public InventoryWallMoveTwoStepView(InventoryWallMoveTwoStepViewModel inventoryWallMoveTwoStepViewModel)
	{
		InitializeComponent();
        BindingContext = inventoryWallMoveTwoStepViewModel;
    }
}
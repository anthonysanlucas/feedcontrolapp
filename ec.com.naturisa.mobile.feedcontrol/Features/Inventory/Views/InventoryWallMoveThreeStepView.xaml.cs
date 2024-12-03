namespace ec.com.naturisa.mobile.feedcontrol.Features.Inventory.Views;

public partial class InventoryWallMoveThreeStepView : ContentPage
{
	public InventoryWallMoveThreeStepView(InventoryWallMoveThreeStepViewModel inventoryWallMoveThreeStepViewModel)
	{
		InitializeComponent();
		BindingContext = inventoryWallMoveThreeStepViewModel;
	}
}
using DevExpress.Maui.Controls;
using ec.com.naturisa.mobile.feedcontrol.Features.Inventory.ViewModels;

namespace ec.com.naturisa.mobile.feedcontrol.Features.Inventory.Views;

public partial class InventoryWallView : ContentPage
{
	public InventoryWallView(InventoryWallViewModel inventoryWallViewModel)
	{
		InitializeComponent();
        BindingContext = inventoryWallViewModel;
    }	
}
using ec.com.naturisa.mobile.feedcontrol.Features.Inventory.Models;

namespace ec.com.naturisa.mobile.feedcontrol.Features.Inventory.ViewModels;

public partial class InventoryWallViewModel : BaseViewModel
{
    [ObservableProperty]
    public ObservableCollection<InventoryWallResponse> inventoryWallList;

    public InventoryWallViewModel(IToastService toastService) : base(toastService)
    {
        InventoryWallList = new() {
                new InventoryWallResponse
                {
                    poolCode = "NA001",
                    productName = "Aquaxel MW 424 SLD Starter 0.8 mm",
                    sacks = 23,
                    kilograms = 575
                },
                new InventoryWallResponse
                {
                    poolCode = "NA002",
                    productName = "Aquaxel MW 424 SLD Starter 0.8 mm",
                    sacks = 20,
                    kilograms = 500
                },
                new InventoryWallResponse
                {
                    poolCode = "NA003",
                    productName = "Aquaxel MW 424 SLD Starter 0.8 mm",
                    sacks = 30,
                    kilograms = 750
                },
                new InventoryWallResponse
                {
                    poolCode = "NA004",
                    productName = "Aquaxel MW 424 SLD Starter 0.8 mm",
                    sacks = 43,
                    kilograms = 1075
                },
                new InventoryWallResponse
                {
                    poolCode = "NA005",
                    productName = "Aquaxel MW 424 SLD Starter 0.8 mm",
                    sacks = 40,
                    kilograms = 1000
                },
                new InventoryWallResponse
                {
                    poolCode = "NA006",
                    productName = "Aquaxel MW 424 SLD Starter 0.8 mm",
                    sacks = 10,
                    kilograms = 250
                },
                new InventoryWallResponse
                {
                    poolCode = "NA007",
                    productName = "Aquaxel MW 424 SLD Starter 0.8 mm",
                    sacks = 10,
                    kilograms = 250
                },
                new InventoryWallResponse
                {
                    poolCode = "NA008",
                    productName = "Aquaxel MW 424 SLD Starter 0.8 mm",
                    sacks = 10,
                    kilograms = 250
                },
                new InventoryWallResponse
                {
                    poolCode = "NA009",
                    productName = "Aquaxel MW 424 SLD Starter 0.8 mm",
                    sacks = 20,
                    kilograms = 500
                },
                new InventoryWallResponse
                {
                    poolCode = "NA010",
                    productName = "Aquaxel MW 424 SLD Starter 0.8 mm",
                    sacks = 30,
                    kilograms = 750
                },
                new InventoryWallResponse
                {
                    poolCode = "NA011",
                    productName = "Aquaxel MW 424 SLD Starter 0.8 mm",
                    sacks = 10,
                    kilograms = 250
                },
                new InventoryWallResponse
                {
                    poolCode = "NA012",
                    productName = "Aquaxel MW 424 SLD Starter 0.8 mm",
                    sacks = 10,
                    kilograms = 250
                },
                new InventoryWallResponse
                {
                    poolCode = "NA013",
                    productName = "Aquaxel MW 424 SLD Starter 0.8 mm",
                    sacks = 10,
                    kilograms = 250
                },
                new InventoryWallResponse
                {
                    poolCode = "NA014",
                    productName = "Aquaxel MW 424 SLD Starter 0.8 mm",
                    sacks = 10,
                    kilograms = 250
                },
                new InventoryWallResponse
                {
                    poolCode = "NA015",
                    productName = "Aquaxel MW 424 SLD Starter 0.8 mm",
                    sacks = 20,
                    kilograms = 500
                }
        };
    }

    [RelayCommand]
    async Task GoToMoveOneStepView()
    {
        await Shell.Current.GoToAsync(nameof(InventoryWallMoveOneStepView), true);
    }
}

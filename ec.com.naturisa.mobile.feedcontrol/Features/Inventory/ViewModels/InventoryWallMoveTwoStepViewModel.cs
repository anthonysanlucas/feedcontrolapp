namespace ec.com.naturisa.mobile.feedcontrol.Features.Inventory.ViewModels;

public partial class InventoryWallMoveTwoStepViewModel : BaseViewModel
{
    [ObservableProperty]
    private ObservableCollection<ProductWallRow> productRows;

    [ObservableProperty]
    private List<FeedTransferDetailModel> availableProducts;

    public InventoryWallMoveTwoStepViewModel(IToastService toastService) : base(toastService)
    {
        AvailableProducts = new()
        {
             new FeedTransferDetailModel
            {
                ProductId = 5,
                ProductName = "Alimento Iniciador Aquaxel 0.6 MM"
            },
            new FeedTransferDetailModel
            {
                ProductId = 4,
                ProductName = "Aquaxel MW 424 SLD Starter 0.8 mm"
            },
            new FeedTransferDetailModel
            {
                ProductId = 3,
                ProductName = "Cargill Aquaxel MW 354 START NG ext 35% 1.2 mm"
            },
            new FeedTransferDetailModel
            {
                ProductId = 1,
                ProductName = "Aquaxel MW354 Grower NG 1.8"
            },
            new FeedTransferDetailModel
            {
                ProductId = 2,
                ProductName = "Purina Aquafeed 354 CRE NG LS 2.0mm"
            }
        };


        ProductRows = new ObservableCollection<ProductWallRow> { new() };

        ProductRows.CollectionChanged += (sender, args) => UpdateTotals();

        foreach (var row in ProductRows)
        {
            row.PropertyChanged += ProductRow_PropertyChanged;
        }
    }

    private void ProductRow_PropertyChanged(
       object sender,
       System.ComponentModel.PropertyChangedEventArgs e
   )
    {
        if (e.PropertyName == nameof(ProductRow.QuantitySacks))
        {
            OnPropertyChanged(nameof(TotalQuantitySacks));
            OnPropertyChanged(nameof(TotalWeightInKilos));
        }
    }

    public int TotalQuantitySacks =>
    ProductRows.Sum(row => row.QuantitySacks ?? 0);

    public int TotalWeightInKilos => TotalQuantitySacks * 25;

    private void UpdateTotals()
    {
        OnPropertyChanged(nameof(TotalQuantitySacks));
        OnPropertyChanged(nameof(TotalWeightInKilos));
    }
}

public partial class ProductWallRow : ObservableObject
{
    [ObservableProperty]
    private FeedTransferDetailModel selectedProduct;

    [ObservableProperty]
    private int? quantitySacks;
}


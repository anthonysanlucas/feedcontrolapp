namespace ec.com.naturisa.mobile.feedcontrol.Features.Inventory.ViewModels;

public partial class InventoryWallMoveTwoStepViewModel : BaseViewModel
{
    [ObservableProperty]
    private ObservableCollection<ProductWallRow> productRows;

    [ObservableProperty]
    private ObservableCollection<ProductResponse> availableProducts;

    private readonly IProductService _productService;

    public InventoryWallMoveTwoStepViewModel(IToastService toastService, IProductService productService) : base(toastService)
    {
        _productService = productService;

        AvailableProducts = new();

        ProductRows = new ObservableCollection<ProductWallRow> { new() };

        ProductRows.CollectionChanged += (sender, args) => UpdateTotals();

        foreach (var row in ProductRows)
        {
            row.PropertyChanged += ProductRow_PropertyChanged;
        }

        GetAvailableProducts();
    }

    [RelayCommand]
    public async Task AddProductRow()
    {
        //if (!await ValidateFields()) return;

        var newRow = new ProductWallRow();
        newRow.PropertyChanged += ProductRow_PropertyChanged;

        ProductRows.Add(newRow);
        UpdateTotals();
    }

    async void GetAvailableProducts()
    {
        ProductQuery productQuery = new();

        var response = await _productService.GetProducts(productQuery);

        if (response != null && response.Code == 200)
        {
            AvailableProducts = new ObservableCollection<ProductResponse>(response.Data.Data);
        }
        else
        {
            await ToastService.ShowToastAsync("No se ha encontrado ningún producto disponible.");
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
    private ProductResponse selectedProduct;

    [ObservableProperty]
    private int? quantitySacks;
}


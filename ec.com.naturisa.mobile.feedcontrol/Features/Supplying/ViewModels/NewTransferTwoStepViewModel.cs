namespace ec.com.naturisa.mobile.feedcontrol.Features.Distribution.ViewModels
{

    [QueryProperty(nameof(WarehouseTransfer), nameof(WarehouseTransfer))]
    [QueryProperty(nameof(OriginWarehouse), nameof(OriginWarehouse))]
    [QueryProperty(nameof(DestinationWarehouse), nameof(DestinationWarehouse))]
    public partial class NewTransferTwoStepViewModel : BaseViewModel
    {
        [ObservableProperty]
        private WarehouseTransferRequest warehouseTransfer;

        [ObservableProperty]
        private WarehouseResponse originWarehouse;

        [ObservableProperty]
        private WarehouseResponse destinationWarehouse;

        [ObservableProperty]
        private List<FeedTransferDetailModel> availableProducts;

        [ObservableProperty]
        private ObservableCollection<ProductRow> productRows;

        [ObservableProperty]
        private ObservableCollection<Product> addedProducts;

        [ObservableProperty]
        private string vehiclePlate = "GRZ 6396";

        [ObservableProperty]
        private int vehicleCapacity = 528;

        public NewTransferTwoStepViewModel(IToastService toastService)
            : base(toastService)
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

            ProductRows = new ObservableCollection<ProductRow> { new() };

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

        #region commands
        [RelayCommand]
        public void AddProductRow()
        {
            ProductRow newRow = new();
            newRow.PropertyChanged += ProductRow_PropertyChanged;

            ProductRows.Add(newRow);
            UpdateTotals();
        }

        [RelayCommand]
        public void DeleteProductRow(ProductRow row)
        {
            if (!ProductRows.Contains(row))
                return;

            ProductRows.Remove(row);
            UpdateTotals();
        }

        [RelayCommand]
        async Task GoToNewTransferThreeStep()
        {           
            await Shell.Current.GoToAsync(nameof(NewTransferThreeStepView),
                true,
                new Dictionary<string, object>
                {
                    ["WarehouseTransfer"] = WarehouseTransfer,
                    ["OriginWarehouse"] = OriginWarehouse,
                    ["DestinationWarehouse"] = DestinationWarehouse,
                    ["ProductRows"] = ProductRows,
                    ["TotalQuantitySacks"] = TotalQuantitySacks,
                    ["TotalWeight"] = TotalWeightInKilos,
                });
        }
        #endregion

    }

    public partial class ProductRow : ObservableObject
    {
        [ObservableProperty]
        private FeedTransferDetailModel selectedProduct;

        [ObservableProperty]
        private int? quantitySacks;
    }
}

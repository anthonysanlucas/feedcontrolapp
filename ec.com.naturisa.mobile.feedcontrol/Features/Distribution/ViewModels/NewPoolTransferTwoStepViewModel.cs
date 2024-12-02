using ec.com.naturisa.mobile.feedcontrol.Services.Ap1.Pools;
using ec.com.naturisa.mobile.feedcontrol.Services.MasterData.Product;

namespace ec.com.naturisa.mobile.feedcontrol.Features.Distribution.ViewModels
{
    [QueryProperty(nameof(PoolTransferOneStepSelection), nameof(PoolTransferOneStepSelection))]
    public partial class NewPoolTransferTwoStepViewModel : BaseViewModel
    {
        [ObservableProperty]
        private PoolTransferOneStepSelection poolTransferOneStepSelection;

        [ObservableProperty]
        private ObservableCollection<ProductResponse> availableProducts;

        [ObservableProperty]
        private List<FeedTransferDetailPoolModel> availablePools;

        [ObservableProperty]
        private ObservableCollection<PoolTransferTwoStepSelectionModel> productRows;

        [ObservableProperty]
        private ObservableCollection<FeedTransferDetailModel> addedProducts;

        [ObservableProperty]
        private ObservableCollection<PoolsResponse> pools;

        [ObservableProperty]
        private PoolsQuery poolQuery;

        [ObservableProperty]
        private int vehicleCapacity = 165;

        private readonly IPoolsService _poolsService;

        private readonly IProductService _productService;

        public NewPoolTransferTwoStepViewModel(IPoolsService poolsService, IToastService toastService, IProductService productService)
            : base(toastService)
        {
            _poolsService = poolsService;
            _productService = productService;

            PoolQuery = new PoolsQuery
            {
                SubsidiaryId = GlobalData.Instance.SelectedSubsidiary.SubsidiaryId
            };

            GetPoolsBySubsidiary();

            GetAvailableProducts();

            AvailablePools = new()
            {
                new FeedTransferDetailPoolModel { PoolId = 1, PoolCode = "NA001" },
                new FeedTransferDetailPoolModel { PoolId = 2, PoolCode = "NA002" },
                new FeedTransferDetailPoolModel { PoolId = 3, PoolCode = "NA003" },
                new FeedTransferDetailPoolModel { PoolId = 4, PoolCode = "NA004" },
                new FeedTransferDetailPoolModel { PoolId = 5, PoolCode = "NA005" },
                new FeedTransferDetailPoolModel { PoolId = 6, PoolCode = "NA006" },
                new FeedTransferDetailPoolModel { PoolId = 7, PoolCode = "NA007" },
            };

            ProductRows = new ObservableCollection<PoolTransferTwoStepSelectionModel> { new() };

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
            if (e.PropertyName == nameof(PoolTransferTwoStepSelectionModel.QuantitySacks))
            {
                OnPropertyChanged(nameof(TotalQuantitySacks));
                OnPropertyChanged(nameof(TotalWeightInKilos));
                OnPropertyChanged(nameof(RemainingCapacity));
                OnPropertyChanged(nameof(RemainingCapacityVisible));
            }
        }


        #region commands

        [RelayCommand]
        public async Task AddProductRow()
        {
            if (!await ValidateFields()) return;

            var newRow = new PoolTransferTwoStepSelectionModel();
            newRow.PropertyChanged += ProductRow_PropertyChanged;

            ProductRows.Add(newRow);
            UpdateTotals();
        }

        [RelayCommand]
        public void DeletePoolTransfertRow(PoolTransferTwoStepSelectionModel row)
        {
            if (!ProductRows.Contains(row))
                return;

            ProductRows.Remove(row);
            UpdateTotals();
        }

        [RelayCommand]
        public async Task GoToNewPoolTransferThreeStep()
        {
            if (!await ValidateFields()) return;

            await Shell.Current.GoToAsync(
                nameof(NewPoolTransferThreeStepView),
                true,
                new Dictionary<string, object>
                {
                    ["PoolTransferOneStepSelection"] = PoolTransferOneStepSelection,
                    ["PoolTransferTwoStepSelectionModels"] = ProductRows,
                    ["TotalQuantitySacks"] = TotalQuantitySacks,
                    ["TotalWeight"] = TotalWeightInKilos,
                }
            );
        }

        #endregion

        async void GetPoolsBySubsidiary()
        {
            var response = await _poolsService.GetPools(PoolQuery);

            if (response != null && response.Code == 200)
            {
                Pools = new ObservableCollection<PoolsResponse>(response.Data.Data);
            }
            else
            {
                await ToastService.ShowToastAsync("Error al cargar las piscinas.");
            }
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
                await ToastService.ShowToastAsync("Error al cargar los productos.");
            }
        }

        public int TotalQuantitySacks => ProductRows.Sum(row => row.QuantitySacks ?? 0);

        public int TotalWeightInKilos => TotalQuantitySacks * 25;

        public int RemainingCapacity => VehicleCapacity - TotalQuantitySacks;

        public int RemainingCapacityVisible => RemainingCapacity > 0 ? RemainingCapacity : 0;

        private void UpdateTotals()
        {
            OnPropertyChanged(nameof(TotalQuantitySacks));
            OnPropertyChanged(nameof(TotalWeightInKilos));
            OnPropertyChanged(nameof(RemainingCapacity));
            OnPropertyChanged(nameof(RemainingCapacityVisible));
        }

        private async Task<bool> ValidateFields()
        {
            if (RemainingCapacity < 0)
            {
                int sacks = Math.Abs(RemainingCapacity);

                await ToastService.ShowToastAsync($"Tienes {sacks} sacos más de la capacidad máxima del vehículo.");
                return false;
            }

            foreach (var row in ProductRows)
            {
                if (row.SelectedProduct == null || row.SelectedPool == null || row.QuantitySacks == null)
                {
                    await ToastService.ShowToastAsync("Todos los campos de las filas deben estar completos.");
                    return false;
                }
            }

            return true;
        }
    }

    public partial class PoolTransferTwoStepSelectionModel : ObservableObject
    {
        [ObservableProperty]
        private ProductResponse selectedProduct;

        [ObservableProperty]
        private PoolsResponse selectedPool;

        [ObservableProperty]
        private int? quantitySacks;
    }
}

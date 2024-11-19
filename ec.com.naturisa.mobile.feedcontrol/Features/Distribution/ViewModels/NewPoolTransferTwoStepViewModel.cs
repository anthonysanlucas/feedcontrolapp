using ec.com.naturisa.mobile.feedcontrol.Services.Ap1.Pools;

namespace ec.com.naturisa.mobile.feedcontrol.Features.Distribution.ViewModels
{
    [QueryProperty(nameof(PoolTransferOneStepSelection), nameof(PoolTransferOneStepSelection))]
    public partial class NewPoolTransferTwoStepViewModel : BaseViewModel
    {
        [ObservableProperty]
        private PoolTransferOneStepSelection poolTransferOneStepSelection;

        [ObservableProperty]
        private List<FeedTransferDetailModel> availableProducts;

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

        public NewPoolTransferTwoStepViewModel(IPoolsService poolsService, IToastService toastService)
            : base(toastService)
        {
            _poolsService = poolsService;

            PoolQuery = new PoolsQuery
            {
                SubsidiaryId = GlobalData.Instance.SelectedSubsidiary.SubsidiaryId
            };

            GetPoolsBySubsidiary();

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
                async Task ShowError()
                {
                    await ToastService.ShowToastAsync("Error al obtener las piscinas.");

                }
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
        private FeedTransferDetailModel selectedProduct;

        [ObservableProperty]
        private PoolsResponse selectedPool;

        [ObservableProperty]
        private int? quantitySacks;
    }
}

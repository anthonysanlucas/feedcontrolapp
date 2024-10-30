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
        private int vehicleCapacity = 165;

        public NewPoolTransferTwoStepViewModel(IToastService toastService)
            : base(toastService)
        {
            AvailableProducts = new()
            {
                new FeedTransferDetailModel
                {
                    ProductId = 1,
                    ProductName = "ALIMENTO INICIADOR AQUAXCEL 0.6 MM"
                },
                new FeedTransferDetailModel
                {
                    ProductId = 3,
                    ProductName = "NATURISA STARTER 0.8MM"
                },
                new FeedTransferDetailModel
                {
                    ProductId = 2,
                    ProductName = "NATURISA ADVANCE STD 1.2MM"
                },
                 new FeedTransferDetailModel
                {
                    ProductId = 4,
                    ProductName = "AQUAXCEL MW354 GROWER NG 1.8"
                },
            };

            AvailablePools = new()
            {
                new FeedTransferDetailPoolModel { PoolId = 1, PoolCode = "MA001" },
                new FeedTransferDetailPoolModel { PoolId = 2, PoolCode = "MA002" },
                new FeedTransferDetailPoolModel { PoolId = 3, PoolCode = "MA003" },
                new FeedTransferDetailPoolModel { PoolId = 4, PoolCode = "MA004" },
                new FeedTransferDetailPoolModel { PoolId = 5, PoolCode = "MA005" },
                new FeedTransferDetailPoolModel { PoolId = 6, PoolCode = "MA006" },
                new FeedTransferDetailPoolModel { PoolId = 7, PoolCode = "MA007" },
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
            }
        }

        [RelayCommand]
        public async void AddProductRow()
        {
            if (RemainingCapacity < 0)
            {
                await ToastService.ShowToastAsync(
                    "No se puede superar la capacidad máxima del vehículo."
                );
                return;
            }

            var newRow = new PoolTransferTwoStepSelectionModel();
            newRow.PropertyChanged += ProductRow_PropertyChanged;

            ProductRows.Add(newRow);
            UpdateTotals();
        }

        [RelayCommand]
        public void DeleteProductRow(PoolTransferTwoStepSelectionModel row)
        {
            if (!ProductRows.Contains(row))
                return;

            ProductRows.Remove(row);
            UpdateTotals();
        }

        [RelayCommand]
        public async Task GoToNewPoolTransferThreeStep()
        {
            if (RemainingCapacity < 0)
            {
                await ToastService.ShowToastAsync(
                    "No se puede superar la capacidad máxima del vehículo."
                );
                return;
            }

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

        public int TotalQuantitySacks => ProductRows.Sum(row => row.QuantitySacks ?? 0);

        public int TotalWeightInKilos => TotalQuantitySacks * 25;

        public int RemainingCapacity => VehicleCapacity - TotalQuantitySacks;

        private void UpdateTotals()
        {
            OnPropertyChanged(nameof(TotalQuantitySacks));
            OnPropertyChanged(nameof(TotalWeightInKilos));
            OnPropertyChanged(nameof(RemainingCapacity));
        }
    }

    public partial class PoolTransferTwoStepSelectionModel : ObservableObject
    {
        [ObservableProperty]
        private FeedTransferDetailModel selectedProduct;

        [ObservableProperty]
        private FeedTransferDetailPoolModel selectedPool;

        [ObservableProperty]
        private int? quantitySacks;
    }
}

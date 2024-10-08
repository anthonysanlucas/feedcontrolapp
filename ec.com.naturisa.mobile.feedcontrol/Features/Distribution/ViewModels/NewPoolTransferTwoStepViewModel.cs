namespace ec.com.naturisa.mobile.feedcontrol.Features.Distribution.ViewModels
{
    public partial class NewPoolTransferTwoStepViewModel : BaseViewModel
    {
        [ObservableProperty]
        private List<string> availableProducts;

        [ObservableProperty]
        private List<string> availablePools;

        [ObservableProperty]
        private int vehicleCapacity;

        [ObservableProperty]
        private ObservableCollection<PoolTransferRow> poolTransferRows;

        [ObservableProperty]
        private ObservableCollection<Product> addedProducts;

        public NewPoolTransferTwoStepViewModel(IToastService toastService)
            : base(toastService)
        {
            VehicleCapacity = 165;

            AvailableProducts = new List<string>
            {
                "AQUAXCEL MW 424 SLD STARTER 0.8 MM",
                "AQUAXCEL MW 424 SLD STARTER 0.6 MM",
                "AQUAXCEL SLD 1.2 MM"
            };

            AvailablePools = new List<string> { "MA001", "MA002", "MA003", "MA005" };

            PoolTransferRows = new ObservableCollection<PoolTransferRow>();

            PoolTransferRows.Add(
                new PoolTransferRow
                {
                    SelectedPool = "",
                    SelectedProduct = "",
                    QuantitySacks = null
                }
            );

            PoolTransferRows.CollectionChanged += (sender, args) => UpdateTotals();

            foreach (var row in PoolTransferRows)
            {
                row.PropertyChanged += PoolTransferRow_PropertyChanged;
            }
        }

        private void PoolTransferRow_PropertyChanged(
            object sender,
            System.ComponentModel.PropertyChangedEventArgs e
        )
        {
            if (e.PropertyName == nameof(PoolTransferRow.QuantitySacks))
            {
                OnPropertyChanged(nameof(TotalQuantitySacks));
                OnPropertyChanged(nameof(TotalWeightInKilos));
            }
        }

        [RelayCommand]
        public async void AddPoolTransferRow()
        {
            if (RemainingCapacity < 0)
            {
                await ToastService.ShowToastAsync(
                    "No se puede superar la capacidad máxima del vehículo"
                );

                return;
            }

            PoolTransferRow newRow = new();
            newRow.PropertyChanged += PoolTransferRow_PropertyChanged;

            PoolTransferRows.Add(newRow);
            UpdateTotals();
        }

        [RelayCommand]
        public void DeletePoolTransfertRow(PoolTransferRow row)
        {
            if (!PoolTransferRows.Contains(row))
                return;

            PoolTransferRows.Remove(row);
            UpdateTotals();
        }

        [RelayCommand]
        async Task GoToNewPoolTransferThreeStep()
        {
            if (RemainingCapacity < 0)
            {
                await ToastService.ShowToastAsync(
                    "No se puede superar la capacidad máxima del vehículo."
                );

                return;
            }

            await Shell.Current.GoToAsync(nameof(NewPoolTransferThreeStepView));
        }

        public int TotalQuantitySacks =>
            PoolTransferRows.Sum(row => int.TryParse(row.QuantitySacks, out int sacks) ? sacks : 0);

        public int TotalWeightInKilos => TotalQuantitySacks * 25;

        public int RemainingCapacity => VehicleCapacity - TotalQuantitySacks;

        private void UpdateTotals()
        {
            OnPropertyChanged(nameof(TotalQuantitySacks));
            OnPropertyChanged(nameof(TotalWeightInKilos));
            OnPropertyChanged(nameof(RemainingCapacity));
        }
    }

    public partial class PoolTransferRow : ObservableObject
    {
        [ObservableProperty]
        private string selectedPool;

        [ObservableProperty]
        private string selectedProduct;

        [ObservableProperty]
        private string quantitySacks;
    }
}

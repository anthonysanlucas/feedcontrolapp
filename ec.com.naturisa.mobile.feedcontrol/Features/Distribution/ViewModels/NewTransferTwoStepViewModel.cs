namespace ec.com.naturisa.mobile.feedcontrol.Features.Distribution.ViewModels
{
    public partial class NewTransferTwoStepViewModel : BaseViewModel
    {
        [ObservableProperty]
        private List<string> availableProducts;

        [ObservableProperty]
        private ObservableCollection<ProductRow> productRows;

        [ObservableProperty]
        private ObservableCollection<Product> addedProducts;

        public NewTransferTwoStepViewModel(IToastService toastService)
            : base(toastService)
        {
            availableProducts = new List<string>
            {
                "AQUAXCEL MW 424 SLD STARTER 0.8 MM",
                "AQUAXCEL MW 424 SLD STARTER 0.6 MM",
                "AQUAXCEL SLD 1.2 MM"
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
            await Shell.Current.GoToAsync(nameof(NewTransferThreeStepView));
        }

        public int TotalQuantitySacks =>
            ProductRows.Sum(row => int.TryParse(row.QuantitySacks, out int sacks) ? sacks : 0);

        public int TotalWeightInKilos => TotalQuantitySacks * 25;

        private void UpdateTotals()
        {
            OnPropertyChanged(nameof(TotalQuantitySacks));
            OnPropertyChanged(nameof(TotalWeightInKilos));
        }
    }

    public partial class ProductRow : ObservableObject
    {
        [ObservableProperty]
        private string selectedProduct;

        [ObservableProperty]
        private string quantitySacks;
    }
}

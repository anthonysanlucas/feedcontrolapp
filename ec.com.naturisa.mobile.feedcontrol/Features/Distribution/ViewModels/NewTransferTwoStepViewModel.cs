namespace ec.com.naturisa.mobile.feedcontrol.Features.Distribution.ViewModels
{
    public partial class NewTransferTwoStepViewModel : BaseViewModel
    {
        [ObservableProperty]
        private List<string> availableProducts;

        [ObservableProperty]
        private string selectedProduct;

        [ObservableProperty]
        private string quantity;

        [ObservableProperty]
        private ObservableCollection<Product> addedProducts;

        public NewTransferTwoStepViewModel(IToastService toastService)
            : base(toastService)
        {
            availableProducts = new List<string>
            {
                "AQUAXCEL MW 424 SLD STARTER 0.8 MM",
                "Producto 2",
                "Producto 3"
            };
            addedProducts = new ObservableCollection<Product>();
        }

        [RelayCommand]
        async Task AddProduct()
        {
            if (string.IsNullOrEmpty(selectedProduct) || string.IsNullOrEmpty(quantity))
            {
                await ToastService.ShowToastAsync(
                    "Por favor selecciona un producto e ingresa una cantidad."
                );
                return;
            }

            int IntQuantity = int.Parse(quantity);

            // Agrega el producto a la lista
            addedProducts.Add(
                new Product
                {
                    ProductName = selectedProduct,
                    ProductDetails = $"{quantity} SACOS - {IntQuantity * 25} KG"
                }
            );

            // Reiniciar selección
            selectedProduct = null;
            quantity = string.Empty;

            await ToastService.ShowToastAsync("Producto agregado correctamente.");
        }

        [RelayCommand]
        async Task GoToNewTransferThreeStep()
        {
            await Shell.Current.GoToAsync(nameof(NewTransferThreeStepView));
        }
    }
}

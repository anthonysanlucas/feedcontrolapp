using ec.com.naturisa.mobile.feedcontrol.Models.SupplierTransfer;
using ec.com.naturisa.mobile.feedcontrol.Services.SupplierTransferService;

namespace ec.com.naturisa.mobile.feedcontrol.Features.Distribution.ViewModels
{
    public partial class WarehouseTransferViewModel : BaseViewModel
    {
        private readonly SupplierTransferService _supplierTransferService;

        [ObservableProperty]
        private ObservableCollection<SupplierTransferResponse> supplierTransfers;

        public WarehouseTransferViewModel(IToastService toastService)
            : base(toastService) {
            _supplierTransferService = new SupplierTransferService();

            GetSupplierTransfers();

        }

        #region Commands
        [RelayCommand]
        async Task CreateTransfer()
        {
            await Shell.Current.GoToAsync(nameof(NewTransferOneStepView));
        }

        [RelayCommand]
        async Task GoToTransferDetail()
        {
            await Shell.Current.GoToAsync(nameof(TransferDetailView));
        }

        [RelayCommand]
        async Task GetSupplierTransfers()
        {
            IsNotBusy = false;
            IsBusy = true;
            IsRefreshing = false;

            var response = await _supplierTransferService.GetSupplierTransfers(new SupplierTransferQuery
            {
                AssignmentDate = DateTime.Now,
                IncludeFreightTransporter = true,
                DestinationOperatorWarehouseUserId = 20051,
                IncludeStatusCatalogue = true,
                IncludeStatusCatalogueList = true,
                IncludeSupplier = true,
                IncludeSupplierTransferDetails = true,
                IncludeTransport = true,
                Status = "ACTIVO",
                StatusCatalogueName = [SupplierTransferConstants.Finished]
            });

            if (response != null && response.Data != null && response.Data.Data.Any())
            {
                var data = response.Data.Data;

                supplierTransfers = new ObservableCollection<SupplierTransferResponse>(data);
            }

            IsBusy = false;
            IsNotBusy = true;
        }

        #endregion
    }
}

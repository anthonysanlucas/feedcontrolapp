using ec.com.naturisa.mobile.feedcontrol.Models.SupplierTransfer;

namespace ec.com.naturisa.mobile.feedcontrol.Features.Distribution.ViewModels
{
    public partial class WarehouseTransferViewModel : BaseViewModel
    {
        private readonly SupplierTransferService _supplierTransferService;

        [ObservableProperty]
        private ObservableCollection<SupplierTransferResponse> supplierTransfers;

        [ObservableProperty]
        private SupplierTransferQuery filterQuery;


        public WarehouseTransferViewModel(IToastService toastService)
            : base(toastService)
        {
            _supplierTransferService = new SupplierTransferService();
            FilterQuery = new SupplierTransferQuery
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
                StatusCatalogueName = [Const.Status.Transfer.AtDestination, SupplierTransferConstants.Delivered]
            };

            GetSupplierTransfers();



        }

        #region Commands
        [RelayCommand]
        async Task CreateTransfer()
        {
            await Shell.Current.GoToAsync(nameof(NewTransferOneStepView));
        }

        [RelayCommand]
        async Task GoToTransferDetail(SupplierTransferResponse selectedTransfer)
        {
            if (selectedTransfer != null)
            {
                var navigationParameter = new Dictionary<string, object>
                {
                    { "SelectedTransfer", selectedTransfer }
                };

                await Shell.Current.GoToAsync(nameof(TransferDetailView), navigationParameter);
            }

        }


        [RelayCommand]
        async Task GetSupplierTransfers()
        {
            IsNotBusy = false;
            IsBusy = true;
            IsRefreshing = false;

            var response = await _supplierTransferService.GetSupplierTransfers(FilterQuery);

            if (response != null && response.Data != null && response.Data.Data.Any())
            {
                var data = response.Data.Data;

                SupplierTransfers = new ObservableCollection<SupplierTransferResponse>(data);
            }
            else
            {
                SupplierTransfers?.Clear();
            }

            IsBusy = false;
            IsNotBusy = true;
        }

        public async Task OnConfirmReceptionClicked(object sender, EventArgs e)
        {
            await GetSupplierTransfers();
        }


        #endregion
    }
}

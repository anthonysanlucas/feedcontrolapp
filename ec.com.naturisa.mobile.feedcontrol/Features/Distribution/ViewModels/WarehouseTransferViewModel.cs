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
                DestinationOperatorWarehouseUserId = 2005,
                IncludeStatusCatalogue = true,
                IncludeStatusCatalogueList = true,
                IncludeSupplier = true,
                IncludeSupplierTransferDetails = true,
                IncludeTransport = true,
                Status = "ACTIVO",
                StatusCatalogueName = [Const.Status.Transfer.AtDestination, SupplierTransferConstants.Delivered]
            };
            
            Task.Run(async () => await GetSupplierTransfers());
        }

        #region Commands

        [RelayCommand]
        private async Task CreateTransfer()
        {
            await Shell.Current.GoToAsync(nameof(NewTransferOneStepView));
        }

        [RelayCommand]
        private async Task GoToTransferDetail(SupplierTransferResponse selectedTransfer)
        {
            if (selectedTransfer == null) return;

            var detailStatuses = new[]
            {
                Const.Status.Transfer.Assigned,
                Const.Status.Transfer.Received,
                Const.Status.Transfer.InRoute,
                Const.Status.Transfer.Paused,
                Const.Status.Transfer.Delivered
            };

            if (detailStatuses.Contains(selectedTransfer.LastStatusCatalogueName))
            {
                await Shell.Current.GoToAsync(nameof(TransferDetailView), true, new Dictionary<string, object>
                {
                    { "SelectedTransfer", selectedTransfer }
                });

                return;
            }

            if (selectedTransfer.LastStatusCatalogueName == Const.Status.Transfer.AtDestination)
            {
                await Shell.Current.GoToAsync(nameof(TransferReceptionView), true, new Dictionary<string, object>
                {
                    { "SelectedTransfer", selectedTransfer }
                });

                return;
            }
        }

        [RelayCommand]
        private async Task GetSupplierTransfers()
        {
            IsBusy = true;
            IsNotBusy = false;
            IsRefreshing = false;

            var response = await _supplierTransferService.GetSupplierTransfers(FilterQuery);

            if (response?.Data?.Data != null && response.Data.Data.Any())
            {
                SupplierTransfers = new ObservableCollection<SupplierTransferResponse>(response.Data.Data);
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

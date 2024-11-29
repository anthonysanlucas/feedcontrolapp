namespace ec.com.naturisa.mobile.feedcontrol.Features.Distribution.ViewModels;

public partial class WarehouseTransferViewModel : BaseViewModel, IRecipient<RefreshDataMessage>
{    
    [ObservableProperty]
    private ObservableCollection<SupplierTransferResponse> supplierTransfers;

    [ObservableProperty]
    private SupplierTransferQuery filterQuery;

    private readonly ISupplierTransferService _supplierTransferService;

    public WarehouseTransferViewModel(ISupplierTransferService supplierTransferService,IToastService toastService)
        : base(toastService)
    {
        _supplierTransferService = supplierTransferService;

        WeakReferenceMessenger.Default.Register<RefreshDataMessage>(this);

        FilterQuery = new SupplierTransferQuery
        {
            AssignmentDate = DateTime.Now,
            IncludeFreightTransporter = true,
            DestinationOperatorWarehouseUserId = GlobalData.Instance.UserData.IdUser,
            IncludeStatusCatalogue = true,
            IncludeStatusCatalogueList = true,
            IncludeSupplier = true,
            IncludeSupplierTransferDetails = true,
            IncludeDestinationWarehouse = true,
            IncludeTransport = true,
            Status = "ACTIVO",
            StatusCatalogueName = [Const.Status.Transfer.Assigned, Const.Status.Transfer.Received, Const.Status.Transfer.InRoute, Const.Status.Transfer.Paused, Const.Status.Transfer.AtDestination, SupplierTransferConstants.Delivered]
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
        };

        var response = await _supplierTransferService.GetSupplierTransfersDetail(selectedTransfer.IdSupplierTransfer);

        if (response?.Data?.Data != null && response.Data.Data.Any())
        {
            selectedTransfer.SupplierTransferDetails = response.Data.Data;
        }

        if (detailStatuses.Contains(selectedTransfer.LastStatusCatalogueName) && selectedTransfer.IsThirdPartyTransport || selectedTransfer.LastStatusCatalogueName == Const.Status.Transfer.AtDestination)
        {
            await Shell.Current.GoToAsync(nameof(TransferReceptionView), true, new Dictionary<string, object>
            {
                { "SelectedTransfer", selectedTransfer }
            });

            return;
        }

        if (detailStatuses.Contains(selectedTransfer.LastStatusCatalogueName) || selectedTransfer.LastStatusCatalogueName == Const.Status.Transfer.Delivered)
        {
            await Shell.Current.GoToAsync(nameof(TransferDetailView), true, new Dictionary<string, object>
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

    public void Receive(RefreshDataMessage message)
    {
        MainThread.BeginInvokeOnMainThread(() =>
        {
            GetSupplierTransfers();
        });
    }
}

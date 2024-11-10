namespace ec.com.naturisa.mobile.feedcontrol.Features.Supplying.ViewModels;

[QueryProperty(nameof(SelectedTransfer), nameof(SelectedTransfer))]
public partial class TransferReceptionViewModel : BaseViewModel
{
    private readonly ISupplierTransferService _supplierTransferService;

    [ObservableProperty]
    private SupplierTransferResponse selectedTransfer;

    public TransferReceptionViewModel(IToastService toastService, ISupplierTransferService supplierTransferService) : base(toastService)
    {
        _supplierTransferService = supplierTransferService;
    }

    #region Commands
    [RelayCommand]
    async Task ReceptTransfer()
    {
        IsNotBusy = false;
        IsBusy = true;
        IsRefreshing = false;

        try
        {
            List<ReceivedDetails> receivedDetails = new List<ReceivedDetails>();

            foreach (var item in SelectedTransfer.SupplierTransferDetails)
            {
                var obj = new ReceivedDetails
                {
                    IdSupplierTransferDetail = item.IdSupplierTransferDetail,
                    QuantityReceivedSacks = item.EquivalenceSacks
                };

                receivedDetails.Add(obj);
            }

            var response = await _supplierTransferService.ChangeStatus(SelectedTransfer.IdSupplierTransfer, SupplierTransferConstants.Delivered, SelectedTransfer.Observation, receivedDetails);

            if (response != null && response.Code != 200)
            {
                throw new Exception(response.Message);
            }

            WeakReferenceMessenger.Default.Send(new RefreshDataMessage("REFRESH"));
            await ToastService.ShowToastAsync("Carga recibida correctamente.");

            await Shell.Current.GoToAsync($"//{nameof(WarehouseTransferView)}");
        }
        catch (Exception e)
        {
            await ToastService.ShowToastAsync(e.Message);
        }
        finally
        {
            IsBusy = false;
            IsNotBusy = true;
        }
    }
    #endregion
}

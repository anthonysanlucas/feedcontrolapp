namespace ec.com.naturisa.mobile.feedcontrol.Features.Distribution.ViewModels
{
    [QueryProperty(nameof(SelectedTransfer), "SelectedTransfer")]
    public partial class TransferDetailViewModel : BaseViewModel
    {
        private readonly SupplierTransferService _supplierTransferService;

        [ObservableProperty]
        private SupplierTransferResponse selectedTransfer;

        public TransferDetailViewModel(IToastService toastService)
            : base(toastService) {
            _supplierTransferService = new SupplierTransferService();
        }

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
                await ToastService.ShowToastAsync(
                    "Operación realizada con éxito.",
                    ToastDuration.Long
                );
                //WeakReferenceMessenger.Default.Send(new RefreshDataMessenger(true));

                await Shell.Current.GoToAsync($"//{nameof(WarehouseTransferView)}");
            }
            catch (Exception e)
            {
                await ToastService.ShowToastAsync(
                    e.Message,
                    ToastDuration.Long
                );
            }
            finally
            {
                IsBusy = false;
                IsNotBusy = true;

            }

        }    
    }
}

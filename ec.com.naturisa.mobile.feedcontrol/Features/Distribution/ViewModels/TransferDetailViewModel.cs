using ec.com.naturisa.mobile.feedcontrol.Models.SupplierTransfer;

namespace ec.com.naturisa.mobile.feedcontrol.Features.Distribution.ViewModels
{
    [QueryProperty(nameof(SelectedTransfer), "SelectedTransfer")]
    public partial class TransferDetailViewModel : BaseViewModel
    {
        public SupplierTransferResponse SelectedTransfer { get; set; }

        public TransferDetailViewModel(IToastService toastService)
            : base(toastService) { }

        [RelayCommand]
        async Task ReceptTransfer()
        {
            await ToastService.ShowToastAsync(
                "El transportista debe completar la ruta antes de recibir la transferencia.",
                ToastDuration.Long
            );
        }

        public void Initialize()
        {
            Console.WriteLine(SelectedTransfer?.Code);
        }

    }
}

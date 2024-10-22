namespace ec.com.naturisa.mobile.feedcontrol.Features.Distribution.ViewModels
{
    public partial class TransferDetailViewModel : BaseViewModel
    {
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
    }
}

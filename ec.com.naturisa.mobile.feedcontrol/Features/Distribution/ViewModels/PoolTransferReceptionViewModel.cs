namespace ec.com.naturisa.mobile.feedcontrol.Features.Distribution.ViewModels
{
    [QueryProperty(nameof(SelectedTransfer), nameof(SelectedTransfer))]
    public partial class PoolTransferReceptionViewModel : BaseViewModel
    {
        private readonly IFeedTransferService _feedTransferService;

        [ObservableProperty]
        private FeedTransferModel selectedTransfer;

        public PoolTransferReceptionViewModel(
            IToastService toastService,
            IFeedTransferService feedTransferService
        )
            : base(toastService)
        {
            _feedTransferService = feedTransferService;
        }

        [RelayCommand]
        async Task UpdateToReceivedFeedTransferStatus(int id)
        {
            try
            {
                var response = await _feedTransferService.PatchFeedTransferStatus(id, "RECIBIDO");

                if (response != null && response.Code == 200)
                {
                    await ToastService.ShowToastAsync("Estado actualizado exitosamente.");

                    // Ir a la otra pantalla de Iniciar ruta
                }
                else
                {
                    await ToastService.ShowToastAsync("Error al actualizar el estado.");
                }
            }
            catch (Exception ex)
            {
                await ToastService.ShowToastAsync("Ocurrió un error, intente nuevamente.);
            }
        }
    }
}

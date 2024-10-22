namespace ec.com.naturisa.mobile.feedcontrol.Features.Distribution.ViewModels
{
    [QueryProperty(nameof(SelectedTransferPoolDetail), nameof(SelectedTransferPoolDetail))]
    public partial class PoolTransferDeliveryDetailViewModel : BaseViewModel
    {
        [ObservableProperty]
        private FeedTransferPoolDetailCustomResponse selectedTransferPoolDetail;

        //private readonly IFeedTransferService _feedTransferService;

        //private readonly IFeedTransferDetailService _feedTransferDetailService;

        private readonly IFeedTransferDetailPoolService _feedTransferDetailPoolService;

        public PoolTransferDeliveryDetailViewModel(
            IToastService toastService,
            IFeedTransferDetailPoolService feedTransferDetailPoolService
        )
            : base(toastService)
        {
            _feedTransferDetailPoolService = feedTransferDetailPoolService;
        }

        #region Commands

        [RelayCommand]
        async Task UpdateToDeliveryStatus()
        {
            try
            {
                IsBusy = true;

                int id = (int)SelectedTransferPoolDetail.IdFeedTransferDetailPool;

                var response = await _feedTransferDetailPoolService.ChangeStatus(
                    id,
                    Const.Status.Transfer.Delivered
                );

                if (response != null && response.Code == 200)
                {
                    await ToastService.ShowToastAsync("Estado actualizado exitosamente.");

                    await Shell.Current.GoToAsync("..");
                }
                else
                {
                    await ToastService.ShowToastAsync(
                        "Error al actualizar el estado, intente nuevamente."
                    );
                }
            }
            catch (Exception ex)
            {
                await ToastService.ShowToastAsync("Ocurrió un error, intente nuevamente.");
            }
            finally
            {
                IsBusy = false;
            }
        }

        #endregion
    }
}

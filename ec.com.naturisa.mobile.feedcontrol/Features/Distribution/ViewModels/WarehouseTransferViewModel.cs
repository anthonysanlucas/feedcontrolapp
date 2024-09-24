namespace ec.com.naturisa.mobile.feedcontrol.Features.Distribution.ViewModels
{
    public partial class WarehouseTransferViewModel : BaseViewModel
    {
        public WarehouseTransferViewModel(IToastService toastService)
            : base(toastService) { }

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

        #endregion
    }
}

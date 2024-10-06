namespace ec.com.naturisa.mobile.feedcontrol.Features.Distribution.ViewModels
{
    public partial class PoolTransferViewModel : BaseViewModel
    {
        public PoolTransferViewModel(IToastService toastService)
            : base(toastService) { }

        [RelayCommand]
        async Task CreateTransfer()
        {
            await Shell.Current.GoToAsync(nameof(NewPoolTransferOneStepView));
        }
    }
}

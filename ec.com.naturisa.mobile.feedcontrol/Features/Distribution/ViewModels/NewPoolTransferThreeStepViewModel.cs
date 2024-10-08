namespace ec.com.naturisa.mobile.feedcontrol.Features.Distribution.ViewModels
{
    public partial class NewPoolTransferThreeStepViewModel : BaseViewModel
    {
        public NewPoolTransferThreeStepViewModel(IToastService toastService)
            : base(toastService) { }

        [RelayCommand]
        async Task GoToPoolTransferView()
        {
            await Shell.Current.GoToAsync(nameof(PoolTransferView));
        }
    }
}

namespace ec.com.naturisa.mobile.feedcontrol.Features.Distribution.ViewModels
{
    public partial class FeedingPoolTwoStepViewModel : BaseViewModel
    {
        public FeedingPoolTwoStepViewModel(IToastService toastService)
            : base(toastService) { }

        [RelayCommand]
        async Task CompleteFeed()
        {
            await Shell.Current.GoToAsync(nameof(FeedingPoolTwoStepView));
        }
    }
}

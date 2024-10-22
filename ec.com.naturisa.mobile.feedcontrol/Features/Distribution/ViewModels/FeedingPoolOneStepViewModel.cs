namespace ec.com.naturisa.mobile.feedcontrol.Features.Distribution.ViewModels
{
    public partial class FeedingPoolOneStepViewModel : BaseViewModel
    {
        public FeedingPoolOneStepViewModel(IToastService toastService)
            : base(toastService) { }

        [RelayCommand]
        async Task GoToFeedingPoolTwoStep()
        {
            await Shell.Current.GoToAsync(nameof(FeedingPoolTwoStepView));
        }
    }
}

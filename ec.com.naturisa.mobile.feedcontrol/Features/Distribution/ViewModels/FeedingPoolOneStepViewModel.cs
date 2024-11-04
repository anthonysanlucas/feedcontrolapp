namespace ec.com.naturisa.mobile.feedcontrol.Features.Distribution.ViewModels
{
    [QueryProperty(nameof(Feed), nameof(Feed))]
    public partial class FeedingPoolOneStepViewModel : BaseViewModel
    {
        [ObservableProperty]
        private FeedResponse feed;

        public FeedingPoolOneStepViewModel(IToastService toastService)
            : base(toastService) { }

        [RelayCommand]
        async Task GoToFeedingPoolTwoStep()
        {
            await Shell.Current.GoToAsync(nameof(FeedingPoolTwoStepView));
        }
    }
}

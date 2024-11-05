namespace ec.com.naturisa.mobile.feedcontrol.ViewModels
{
    public partial class FeedingRemainingDetailViewModel : BaseViewModel
    {
        public FeedingRemainingDetailViewModel(IToastService toastService)
            : base(toastService) { }


        [RelayCommand]
        async Task GoToFeedingRemaining()
        {
            // await Shell.Current.GoToAsync($"//{nameof(FeedingRemainingDetailView)}");

            // await Shell.Current.GoToAsync("..");

           await Shell.Current.Navigation.PopAsync(true);
        }
    }
}

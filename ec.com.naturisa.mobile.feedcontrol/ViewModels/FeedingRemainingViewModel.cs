namespace ec.com.naturisa.mobile.feedcontrol.ViewModels
{
    public partial class FeedingRemainingViewModel : BaseViewModel
    {
        public ObservableCollection<PoolFeedingAndRemainingState> PoolFeedingRemainingList { get; set; }

        public FeedingRemainingViewModel(IToastService toastService)
            : base(toastService)
        {
            PoolFeedingRemainingList = new ObservableCollection<PoolFeedingAndRemainingState>
            {
                new()
                {
                    PoolName = "MA 003",
                    IsFeeding = true,
                    IsRemaining = false
                },
                new()
                {
                    PoolName = "MA 004",
                    IsFeeding = true,
                    IsRemaining = true
                },                
            };
        }

        #region commands

        [RelayCommand]
        async Task GoToFeedingRemainingDetail()
        {
            await Shell.Current.GoToAsync(nameof(FeedingRemainingDetailView));
        }

        #endregion
    }
}

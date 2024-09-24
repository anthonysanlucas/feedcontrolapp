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
                    PoolName = "MA 001",
                    IsFeeding = true,
                    IsRemaining = false
                },
                new()
                {
                    PoolName = "MA 002",
                    IsFeeding = true,
                    IsRemaining = true
                },
                new()
                {
                    PoolName = "MA 003",
                    IsFeeding = true,
                    IsRemaining = true
                },
                new()
                {
                    PoolName = "MA 004",
                    IsFeeding = true,
                    IsRemaining = true
                },
                new()
                {
                    PoolName = "MA 005",
                    IsFeeding = true,
                    IsRemaining = true
                },
                new()
                {
                    PoolName = "MA 006",
                    IsFeeding = true,
                    IsRemaining = true
                },
                new()
                {
                    PoolName = "MA 007",
                    IsFeeding = true,
                    IsRemaining = true
                },
                new()
                {
                    PoolName = "MA 008",
                    IsFeeding = false,
                    IsRemaining = true
                },
                new()
                {
                    PoolName = "MA 009",
                    IsFeeding = false,
                    IsRemaining = true
                },
                new()
                {
                    PoolName = "MA 010",
                    IsFeeding = false,
                    IsRemaining = true
                },
                new()
                {
                    PoolName = "MA 011",
                    IsFeeding = false,
                    IsRemaining = true
                },
                new()
                {
                    PoolName = "MA 012",
                    IsFeeding = false,
                    IsRemaining = true
                }
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

namespace ec.com.naturisa.mobile.feedcontrol.Features.Distribution.ViewModels
{
    public partial class FeedingPoolViewModel : BaseViewModel
    {
        public ObservableCollection<PoolFeedingAndRemainingState> PoolFeedingList { get; set; }

        private readonly IFeedService _feedService;

        public FeedingPoolViewModel(IToastService toastService, IFeedService feedService)
            : base(toastService)
        {
            _feedService = feedService;

            PoolFeedingList = new ObservableCollection<PoolFeedingAndRemainingState>
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

            GetFeeds();
        }

        #region commands

        [RelayCommand]
        async Task GoToFeedingDetail()
        {
            await Shell.Current.GoToAsync(nameof(FeedingPoolDetailView));
        }

        [RelayCommand]
        async Task GoToFeedingPoolOneStep()
        {
            await Shell.Current.GoToAsync(nameof(FeedingPoolOneStepView));
        }

        [RelayCommand]
        async Task GetFeeds()
        {
            var response = await _feedService.GetFeeds(new FeedQuery());

            Console.WriteLine(response);
        }

        #endregion
    }
}

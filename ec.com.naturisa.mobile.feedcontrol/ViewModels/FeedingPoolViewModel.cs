using System.Collections.ObjectModel;
using ec.com.naturisa.mobile.feedcontrol.Models;

namespace ec.com.naturisa.mobile.feedcontrol.ViewModels
{
    public partial class FeedingPoolViewModel : BaseViewModel
    {
        [ObservableProperty]
        private double collectionViewWidth;

        public ObservableCollection<PoolFeedingAndRemainingState> PoolFeedingList { get; set; }

        public FeedingPoolViewModel(IToastService toastService)
            : base(toastService)
        {
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

        #endregion
    }
}

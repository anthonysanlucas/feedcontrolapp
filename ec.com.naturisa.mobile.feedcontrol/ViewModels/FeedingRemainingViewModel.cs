namespace ec.com.naturisa.mobile.feedcontrol.ViewModels
{
    public partial class FeedingRemainingViewModel : BaseViewModel
    {
        [ObservableProperty]
        public ObservableCollection<PoolFeedingAndRemainingState> poolFeedingRemainingList;

        public FeedingRemainingViewModel(IToastService toastService)
            : base(toastService)
        {
            PoolFeedingRemainingList = new ObservableCollection<PoolFeedingAndRemainingState>
            {
                new()
                {
                    PoolName = "MA003",
                    IsFeeding = false,
                    IsRemaining = false
                },
                new()
                {
                    PoolName = "MA004",
                    IsFeeding = false,
                    IsRemaining = false
                },
                new()
                {
                    PoolName = "MA005",
                    IsFeeding = false,
                    IsRemaining = false
                },
                 new()
                {
                    PoolName = "MA006",
                    IsFeeding = false,
                    IsRemaining = false
                },
                  new()
                {
                    PoolName = "MA007",
                    IsFeeding = false,
                    IsRemaining = false
                },
                  new()
                {
                    PoolName = "MA008",
                    IsFeeding = false,
                    IsRemaining = false
                },
            };
        }

        public async void SetRemainingStatus(PoolFeedingAndRemainingState item)
        {
            if (item.IsRemaining)
            {
                await ShowToastAsync("El sobrante ha sido registrado en esta piscina.");
                return;
            }

            var index = PoolFeedingRemainingList.IndexOf(PoolFeedingRemainingList.FirstOrDefault(p => p.PoolName == item.PoolName));

            if (index != -1)
            {
                GoToFeedingRemainingDetail(item.PoolName);

                var pool = PoolFeedingRemainingList[index];
                var updatedPool = new PoolFeedingAndRemainingState
                {
                    PoolName = pool.PoolName,
                    IsFeeding = true,
                    IsRemaining = true
                };

                PoolFeedingRemainingList[index] = updatedPool;
            }
        }

        #region commands

        [RelayCommand]
        async Task GoToFeedingRemainingDetail(string poolName)
        {
            await Shell.Current.GoToAsync($"{nameof(FeedingRemainingDetailView)}?poolCode={poolName}");
        }

        [RelayCommand]
        public void UpdateRemainingStatus(PoolFeedingAndRemainingState item)
        {
            SetRemainingStatus(item);
        }

        #endregion
    }
}

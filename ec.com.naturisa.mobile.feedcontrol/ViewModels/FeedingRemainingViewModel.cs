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

        public void SetRemainingStatus(string poolName)
        {
            // Encuentra el índice del elemento en la colección
            var index = PoolFeedingRemainingList.IndexOf(PoolFeedingRemainingList.FirstOrDefault(p => p.PoolName == poolName));

            if (index != -1)
            {
                GoToFeedingRemainingDetail();

                // Captura el registro y actualiza el valor de IsRemaining
                var pool = PoolFeedingRemainingList[index];
                var updatedPool = new PoolFeedingAndRemainingState
                {
                    PoolName = pool.PoolName,
                    IsFeeding = true,
                    IsRemaining = true 
                };

                // Reemplaza el elemento en la colección
                PoolFeedingRemainingList[index] = updatedPool;
            }
        }

        #region commands

        [RelayCommand]
        async Task GoToFeedingRemainingDetail()
        {
            await Shell.Current.GoToAsync(nameof(FeedingRemainingDetailView));
        }

        [RelayCommand]
        public void UpdateRemainingStatus(string poolName)
        {
            SetRemainingStatus(poolName);
        }

        #endregion
    }
}

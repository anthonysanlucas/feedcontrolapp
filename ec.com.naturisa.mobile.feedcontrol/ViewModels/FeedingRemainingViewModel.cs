namespace ec.com.naturisa.mobile.feedcontrol.ViewModels
{    
    public partial class FeedingRemainingViewModel : BaseViewModel
    {
        [ObservableProperty]
        public ObservableCollection<PoolFeedingAndRemainingState> poolFeedingRemainingList;

        [ObservableProperty]
        private FeedResponse feed;        

        [ObservableProperty]
        private ObservableCollection<FeedResponse> feeds;

        [ObservableProperty]
        private FeedRemaningQuery feedRemainingQuery;

        private readonly IFeedService _feedService;

        public FeedingRemainingViewModel(IToastService toastService, IFeedService feedService)
            : base(toastService)
        {
            _feedService = feedService;

            FeedRemainingQuery = new FeedRemaningQuery
            {
                Date = DateTime.Now.ToString("yyyy-MM-dd"),
                //StartDate = DateTime.Now,
                //EndDate = DateTime.Now,
                StatusCatalogueName = [Const.Status.FeedRemaining.Assigned, Const.Status.FeedRemaining.Completed],
                IncludeStatusCatalogue = true
            };

            GetFeeds();           
        }

        

        //public async void SetRemainingStatus(PoolFeedingAndRemainingState item)
        //{
        //    if (item.IsRemaining)
        //    {
        //        await ShowToastAsync("El sobrante ha sido registrado en esta piscina.");
        //        return;
        //    }

        //    var index = PoolFeedingRemainingList.IndexOf(PoolFeedingRemainingList.FirstOrDefault(p => p.PoolName == item.PoolName));

        //    if (index != -1)
        //    {
        //        GoToFeedingRemainingDetail(item.PoolName);

        //        var pool = PoolFeedingRemainingList[index];
        //        var updatedPool = new PoolFeedingAndRemainingState
        //        {
        //            PoolName = pool.PoolName,
        //            IsFeeding = true,
        //            IsRemaining = true
        //        };

        //        PoolFeedingRemainingList[index] = updatedPool;
        //    }
        //}

        #region commands

        [RelayCommand]
        async Task GoToFeedingRemainingDetail(FeedResponse feed)
        {
            if(feed == null)
                return;

            await Shell.Current.GoToAsync(nameof(FeedingRemainingDetailView), true,
               new Dictionary<string, object> { { "Feed", feed } });            
        }

        [RelayCommand]
        public void UpdateRemainingStatus(PoolFeedingAndRemainingState item)
        {
            //SetRemainingStatus(item);
        }

        [RelayCommand]
        async Task GetFeeds()
        {
            try
            {
                IsBusy = true;

                var response = await _feedService.GetFeedRemainings(FeedRemainingQuery);

                if (response.Data != null && response.Data != null)
                {
                    Feeds = new ObservableCollection<FeedResponse>(response.Data.Data);
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                IsBusy = false;
                IsRefreshing = false;
            }
        }

        #endregion
    }
}

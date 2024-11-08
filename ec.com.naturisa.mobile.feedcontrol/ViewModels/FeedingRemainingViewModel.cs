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

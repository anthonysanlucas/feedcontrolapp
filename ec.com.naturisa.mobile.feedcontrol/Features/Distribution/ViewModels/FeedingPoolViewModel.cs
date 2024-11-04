namespace ec.com.naturisa.mobile.feedcontrol.Features.Distribution.ViewModels
{
    public partial class FeedingPoolViewModel : BaseViewModel
    {        
        [ObservableProperty]
        private ObservableCollection<FeedResponse> feeds;       

        [ObservableProperty]
        private FeedQuery feedQuery;
       
        private readonly IFeedService _feedService;

        public FeedingPoolViewModel(IToastService toastService, IFeedService feedService)
            : base(toastService)
        {
            _feedService = feedService;            

            FeedQuery = new FeedQuery
            {
                Date = new DateTime(2024, 10, 29),
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                StatusCatalogueName = [Const.Status.Feed.Assigned, Const.Status.Feed.OnCourse, Const.Status.Feed.Fed],
                IncludeStatusCatalogue = true
            };            

            Task.Run(async () => await GetFeeds());
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
            try
            {
                IsBusy = true;                
                var response = await _feedService.GetFeeds(FeedQuery);

                if(response.Data != null && response.Data.Data != null)
                {
                    Feeds = new ObservableCollection<FeedResponse>(response.Data.Data);
                }

            
            } catch (Exception ex)
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

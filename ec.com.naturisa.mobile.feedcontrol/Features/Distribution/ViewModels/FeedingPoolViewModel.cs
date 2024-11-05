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

            GetFeeds();
        }

        #region commands

        [RelayCommand]
        async Task GoToFeedingDetail()
        {
            await Shell.Current.GoToAsync(nameof(FeedingPoolDetailView));
        }

        [RelayCommand]
        async Task GoToFeedingPoolOneStep(FeedResponse feed)
        {
            if (feed == null)
                return;

            await Shell.Current.GoToAsync(nameof(FeedingPoolOneStepView), true,
                new Dictionary<string, object> { { "Feed", feed } });
        }

        [RelayCommand]
        async Task GetFeeds()
        {
            try
            {
                IsBusy = true;
                Feeds = new ObservableCollection<FeedResponse>
                {
    new FeedResponse
    {
        IdFeed = 2,
        PoolCode = "MA003",
        Date = DateTime.Parse("2024-10-29T09:53:19.943"),
        StatusCatalogueName = "ASIGNADO",
        Status = "ACTIVO",
        CreatedAt = DateTime.Parse("2024-10-29T09:53:20.697"),
        CreatedBy = "btufino",
        FeedDetails = new List<FeedDetail>()
    },
    new FeedResponse
    {
        IdFeed = 1,
        PoolCode = "MA004",
        Date = DateTime.Parse("2024-10-29T08:16:25"),
        StatusCatalogueName = "ASIGNADO",
        Status = "ACTIVO",
        CreatedAt = DateTime.Parse("2024-10-29T08:16:53.143"),
        CreatedBy = "btufino",
        FeedDetails = new List<FeedDetail>()
    },
    new FeedResponse
    {
        IdFeed = 1,
        PoolCode = "MA005",
        Date = DateTime.Parse("2024-10-29T08:16:25"),
        StatusCatalogueName = "ASIGNADO",
        Status = "ACTIVO",
        CreatedAt = DateTime.Parse("2024-10-29T08:16:53.143"),
        CreatedBy = "btufino",
        FeedDetails = new List<FeedDetail>()
    }
    ,
    new FeedResponse
    {
        IdFeed = 1,
        PoolCode = "MA006",
        Date = DateTime.Parse("2024-10-29T08:16:25"),
        StatusCatalogueName = "ASIGNADO",
        Status = "ACTIVO",
        CreatedAt = DateTime.Parse("2024-10-29T08:16:53.143"),
        CreatedBy = "btufino",
        FeedDetails = new List<FeedDetail>()
    }
    ,
    new FeedResponse
    {
        IdFeed = 1,
        PoolCode = "MA007",
        Date = DateTime.Parse("2024-10-29T08:16:25"),
        StatusCatalogueName = "ASIGNADO",
        Status = "ACTIVO",
        CreatedAt = DateTime.Parse("2024-10-29T08:16:53.143"),
        CreatedBy = "btufino",
        FeedDetails = new List<FeedDetail>()
    }
     ,
    new FeedResponse
    {
        IdFeed = 1,
        PoolCode = "MA008",
        Date = DateTime.Parse("2024-10-29T08:16:25"),
        StatusCatalogueName = "ASIGNADO",
        Status = "ACTIVO",
        CreatedAt = DateTime.Parse("2024-10-29T08:16:53.143"),
        CreatedBy = "btufino",
        FeedDetails = new List<FeedDetail>()
    }
};
                //var response = await _feedService.GetFeeds(FeedQuery);

                //if (response.Data != null && response.Data.Data != null)
                //{
                //    Feeds = new ObservableCollection<FeedResponse>(response.Data.Data);
                //}


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

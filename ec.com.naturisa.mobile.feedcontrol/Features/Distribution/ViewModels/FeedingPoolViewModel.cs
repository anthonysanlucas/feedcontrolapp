﻿namespace ec.com.naturisa.mobile.feedcontrol.Features.Distribution.ViewModels
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
                Date = DateTime.Now.ToString("yyyy-MM-dd"),
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

            if (feed.StatusCatalogueName == Const.Status.Feed.Assigned)
            {
                await Shell.Current.GoToAsync(nameof(FeedingPoolOneStepView), true,
                new Dictionary<string, object> { { "Feed", feed } });

                return;
            }

            if (feed.StatusCatalogueName == Const.Status.Feed.OnCourse)
            {
                await Shell.Current.GoToAsync(nameof(FeedingPoolTwoStepView), true,
                new Dictionary<string, object> { { "Feed", feed } });

                return;
            }            
        }

        [RelayCommand]
        async Task GetFeeds()
        {
            try
            {
                IsBusy = true;

                var response = await _feedService.GetFeeds(FeedQuery);

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

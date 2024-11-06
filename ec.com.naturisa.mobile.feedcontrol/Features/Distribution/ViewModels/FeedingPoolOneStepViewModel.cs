

namespace ec.com.naturisa.mobile.feedcontrol.Features.Distribution.ViewModels
{
    [QueryProperty(nameof(Feed), nameof(Feed))]
    public partial class FeedingPoolOneStepViewModel : BaseViewModel
    {
        [ObservableProperty]
        private FeedResponse feed;

        [ObservableProperty]
        private FeedDetailQuery detailQuery;

        [ObservableProperty]
        private ObservableCollection<FeedDetailResponse> feedDetails;

        private readonly IFeedDetailService _feedDetailService;

        public FeedingPoolOneStepViewModel(IToastService toastService, IFeedDetailService feedTransferDetailService)
            : base(toastService)
        {
            _feedDetailService = feedTransferDetailService;
        }

        partial void OnFeedChanged(FeedResponse value)
        {
            if (value != null)
            {
                DetailQuery = new FeedDetailQuery
                {
                    IdFeed = value.IdFeed,
                    IncludeFeed = true
                };

                LoadFeedDetails(DetailQuery);
            }
            return;
        }

        [RelayCommand]
        async Task GoToFeedingPoolTwoStep()
        {
            await Shell.Current.GoToAsync(nameof(FeedingPoolTwoStepView));
        }

        private async void LoadFeedDetails(FeedDetailQuery detailQuery)
        {
            try
            {
                IsBusy = true;
                var feedDetailsResponse = await _feedDetailService.GetFeedDetails(detailQuery);

                if (feedDetailsResponse == null || feedDetailsResponse.Code != 200)
                {
                    await ToastService.ShowToastAsync("Error al cargar los detalles de la alimentación.");
                    return;
                }

                FeedDetails = new ObservableCollection<FeedDetailResponse>(feedDetailsResponse.Data);
            }
            catch (Exception ex)
            {
                await ToastService.ShowToastAsync("Error al cargar los detalles de la alimentación.");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}

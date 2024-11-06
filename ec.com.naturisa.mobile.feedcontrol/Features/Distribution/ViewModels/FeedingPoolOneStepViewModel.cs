

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
        private int sacksRemainingHoppers;

        [ObservableProperty]
        private ObservableCollection<FeedDetailResponse> feedDetails;

        [ObservableProperty]
        private ObservableCollection<FeedOneStep> feedOneSteps;

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
            if (FeedOneSteps == null || FeedOneSteps.Count == 0)
            {
                await ToastService.ShowToastAsync("No se han cargado los detalles de la alimentación.");
                return;
            }

            var newFeedOneSteps = new List<FeedOneStep>();

            foreach (var feedOneStep in FeedOneSteps)
            {
                var feedStep = new FeedOneStep
                {
                    ProductId = feedOneStep.ProductId,
                    SacksFoundWall = feedOneStep.SacksFoundWall,
                    SacksRemainingHoppers = SacksRemainingHoppers
                };

                newFeedOneSteps.Add(feedStep);
            }           

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

                FeedOneSteps = new ObservableCollection<FeedOneStep>();

                foreach (var feedDetail in FeedDetails)
                {
                    FeedOneStep feedOneStep = new FeedOneStep
                    {
                        ProductId = feedDetail.ProductId,
                        ProductName = feedDetail.ProductName,

                    };

                    FeedOneSteps.Add(feedOneStep);
                }
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

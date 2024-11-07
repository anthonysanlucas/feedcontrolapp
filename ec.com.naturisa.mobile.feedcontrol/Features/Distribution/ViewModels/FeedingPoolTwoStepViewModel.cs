namespace ec.com.naturisa.mobile.feedcontrol.Features.Distribution.ViewModels
{
    [QueryProperty(nameof(Feed), nameof(Feed))]
    public partial class FeedingPoolTwoStepViewModel : BaseViewModel
    {
        public ObservableCollection<Observation> PredefinedObservations { get; }

        [ObservableProperty]
        private FeedResponse feed;

        [ObservableProperty]
        private ObservableCollection<FeedDetailResponse> feedDetails;

        [ObservableProperty]
        private FeedDetailQuery detailQuery;

        [ObservableProperty]
        private Observation _selectedObservation;

        [ObservableProperty]
        private string _additionalObservation;

        private readonly IFeedService _feedService;

        private readonly IFeedDetailService _feedDetailService;

        public FeedingPoolTwoStepViewModel(IToastService toastService, IFeedService feedService, IFeedDetailService feedTransferDetailService)
            : base(toastService)
        {
            _feedService = feedService;
            _feedDetailService = feedTransferDetailService;

            PredefinedObservations = new ObservableCollection<Observation>
            {
                new Observation { Name = "Tolva dañada" },
                new Observation { Name = "Balanceado húmedo" },
                new Observation { Name = "Balanceado con grumos" },
                new Observation { Name = "Balanceado con polvillo" }
            };
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

        #region commands

        [RelayCommand]
        async Task CompleteFeed()
        {
            var selectedObs = SelectedObservation?.Name ?? "Sin observación";
            var additionalObs = AdditionalObservation;

            await Shell.Current.GoToAsync(nameof(FeedingPoolTwoStepView));
        }

        #endregion

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

                //FeedOneSteps = new ObservableCollection<FeedOneStep>();

                //foreach (var feedDetail in FeedDetails)
                //{
                //    FeedOneStep feedOneStep = new FeedOneStep
                //    {
                //        ProductId = feedDetail.ProductId,
                //        ProductName = feedDetail.ProductName,

                //    };

                //    FeedOneSteps.Add(feedOneStep);
                //}
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

    public class Observation
    {
        public string Name { get; set; }
        public bool IsSelected { get; set; }
    }
}

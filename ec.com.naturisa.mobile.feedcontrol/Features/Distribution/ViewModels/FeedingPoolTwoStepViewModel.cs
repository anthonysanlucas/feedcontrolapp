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
        private ObservableCollection<FeedTwoStep> feedTwoSteps;

        [ObservableProperty]
        private string _additionalObservation;

        [ObservableProperty]
        private int? loadedHoppers;

        [ObservableProperty]
        private string automaticFeed;

        [ObservableProperty]
        private string voleoFeed;

        [ObservableProperty]
        private int? sacksRemaining;

        [ObservableProperty]
        private string observation;

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
            List<FeedTwoStep> NewFeedTwoSteps = new List<FeedTwoStep>();

            foreach (var feedDetail in FeedDetails)
            {
                FeedTwoStep feedTwoStep = new FeedTwoStep
                {
                    ProductId = feedDetail.ProductId,
                    LoadedHoppers = (int)LoadedHoppers,
                    Observation = Observation,
                    SacksRemainingWallAfterFeeding = (int)SacksRemaining,
                    AutomaticFeeding = "CANOA",
                    ThrowFeeding = "VOLEO"
                };

                NewFeedTwoSteps.Add(feedTwoStep);
            }            

            var response = await _feedService.ChangeFeedStatusTwoStep(DetailQuery.IdFeed, NewFeedTwoSteps);

            if (response == null || response.Code != 200)
            {
                await ShowToastAsync("Error al cambiar el estado de la alimentación.");
                return;
            }

            await ShowToastAsync("Datos registrados correctamente.");

            await Shell.Current.Navigation.PopAsync(true);
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

                FeedTwoSteps = new ObservableCollection<FeedTwoStep>();

                foreach (var feedDetail in FeedDetails)
                {
                    FeedTwoStep feedTwoStep = new FeedTwoStep
                    {
                        ProductId = feedDetail.ProductId,                        
                    };

                    FeedTwoSteps.Add(feedTwoStep);
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

    public class Observation
    {
        public string Name { get; set; }
        public bool IsSelected { get; set; }
    }
}

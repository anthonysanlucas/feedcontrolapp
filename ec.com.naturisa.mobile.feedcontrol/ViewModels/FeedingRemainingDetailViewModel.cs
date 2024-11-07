namespace ec.com.naturisa.mobile.feedcontrol.ViewModels
{
    [QueryProperty(nameof(Feed), nameof(Feed))]
    public partial class FeedingRemainingDetailViewModel : BaseViewModel
    {
        [ObservableProperty]
        private bool isBtnVisible = true;

        [ObservableProperty]
        private string poolCode;

        [ObservableProperty]
        private FeedResponse feed;

        [ObservableProperty]
        private FeedDetailQuery detailQuery;

        [ObservableProperty]
        private int? remainingSacks;

        [ObservableProperty]
        private int? remainingHoppers;

        [ObservableProperty]
        private string remainingObservation;

        private readonly IFeedService _feedService;

        public FeedingRemainingDetailViewModel(IToastService toastService, IFeedService feedService)
            : base(toastService)
        {
            _feedService = feedService;
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
            }
            return;
        }

        [RelayCommand]
        async Task GoToFeedingRemaining()
        {
            // Validación de valores nulos en lugar de 0
            if (RemainingSacks == null || RemainingHoppers == null)
            {
                await ShowToastAsync("Por favor, ingrese todos los datos");
                return;
            }

            IsBtnVisible = false;
            IsBusy = true;

            await Task.Delay(2000);

            await ShowToastAsync("Sobrante registrado correctamente");

            await Shell.Current.Navigation.PopAsync(true);

            IsBtnVisible = true;
            IsBusy = false;
        }

        [RelayCommand]
        async Task CompleteRemaining()
        {            
            if (RemainingSacks == null || RemainingHoppers == null)
            {
                await ShowToastAsync("Por favor, ingrese todos los datos");
                return;
            }

            try
            {
                IsBusy = true;

                FeedRemainingRequest feedRemainingRequest = new FeedRemainingRequest
                {
                    SacksRemainingHoppers = RemainingSacks.Value,
                    FailedHoppers = RemainingHoppers.Value,
                    Observation = RemainingObservation
                };

                var response = await _feedService.ChangeFeedRemainingStatus(Feed.IdFeed, feedRemainingRequest);

                if (response.Code == 200)
                {
                    await ShowToastAsync("Sobrante registrado correctamente");

                    await Shell.Current.Navigation.PopAsync(true);
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                IsBtnVisible = false;
                IsBusy = true;
            }
        }
    }
}

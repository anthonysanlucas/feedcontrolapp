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

            Task.Run(async () =>
            {
                try
                {
                    using var httpClient = new HttpClient();
                    httpClient.Timeout = TimeSpan.FromSeconds(30);

                    // URL de prueba para verificar conectividad
                    var testUrl = "https://jsonplaceholder.typicode.com/todos/1";
                    var response = await httpClient.GetAsync(testUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        Console.WriteLine("Respuesta de la prueba de conectividad:");
                        Console.WriteLine(content);
                    }
                    else
                    {
                        Console.WriteLine($"Error en la solicitud de prueba: {response.StatusCode}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error en la prueba de conexión: {ex.Message}");
                }

                // Luego de la prueba de conectividad, llama a GetFeeds
                await GetFeeds();
            });
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
                var response = await _feedService.GetFeeds(FeedQuery);

                if (response.Data != null && response.Data.Data != null)
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

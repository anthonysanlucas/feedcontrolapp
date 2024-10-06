namespace ec.com.naturisa.mobile.feedcontrol.Features.Distribution.ViewModels
{
    public partial class FeedingPoolTwoStepViewModel : BaseViewModel
    {
        public ObservableCollection<Observation> PredefinedObservations { get; }

        [ObservableProperty]
        private Observation _selectedObservation;

        [ObservableProperty]
        private string _additionalObservation;

        public FeedingPoolTwoStepViewModel(IToastService toastService)
            : base(toastService)
        {
            PredefinedObservations = new ObservableCollection<Observation>
            {
                new Observation { Name = "Tolva dañada" },
                new Observation { Name = "Balanceado húmedo" },
                new Observation { Name = "Balanceado con grumos" },
                new Observation { Name = "Balanceado con polvillo" }
            };
        }

        [RelayCommand]
        async Task CompleteFeed()
        {
            var selectedObs = SelectedObservation?.Name ?? "Sin observación";
            var additionalObs = AdditionalObservation;

            await Shell.Current.GoToAsync(nameof(FeedingPoolTwoStepView));
        }
    }

    public class Observation
    {
        public string Name { get; set; }
        public bool IsSelected { get; set; }
    }
}

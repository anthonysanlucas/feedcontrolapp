using ec.com.naturisa.mobile.feedcontrol.Features.Distribution.Models;

namespace ec.com.naturisa.mobile.feedcontrol.Features.Distribution.ViewModels
{
    [QueryProperty(nameof(FeedTransfer), "FeedTransfer")]
    public partial class FoodReceptionByCarrierViewModel : BaseViewModel
    {
        [ObservableProperty]
        FeedTransfer feedTransfer;

        public FoodReceptionByCarrierViewModel(IToastService toastService)
            : base(toastService) { }

        [RelayCommand]
        async Task CompleteFoodReception()
        {
            await Shell.Current.GoToAsync(nameof(StartOfRouteView));
        }
    }
}

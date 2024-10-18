namespace ec.com.naturisa.mobile.feedcontrol.Views;

public partial class ReceptionOfFoodByCarrier : ContentPage
{
    public ReceptionOfFoodByCarrier(FoodReceptionByCarrierViewModel foodReceptionByCarrierViewModel)
    {
        InitializeComponent();
        BindingContext = foodReceptionByCarrierViewModel;
    }

    [RelayCommand]
    async Task CompleteFoodReception()
    {
        await Shell.Current.GoToAsync(nameof(StartOfRouteView));
    }
}

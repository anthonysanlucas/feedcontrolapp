namespace ec.com.naturisa.mobile.feedcontrol.Views;

public partial class ReceptionOfFoodByCarrier : ContentPage
{
    public ReceptionOfFoodByCarrier(FoodReceptionByCarrierViewModel foodReceptionByCarrierViewModel)
    {
        InitializeComponent();
        BindingContext = foodReceptionByCarrierViewModel;
    }
}

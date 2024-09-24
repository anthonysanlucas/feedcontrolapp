namespace ec.com.naturisa.mobile.feedcontrol.ViewModels
{
    public partial class FarmInventoryViewModel : BaseViewModel
    {
        public FarmInventoryViewModel(IToastService toastService)
            : base(toastService) { }

        #region commands

        [RelayCommand]
        async Task GoToFarmWallInvetory()
        {
            await Shell.Current.GoToAsync(nameof(WallInventoryView));
        }

        [RelayCommand]
        async Task GoToFarmStoreDetail()
        {
            await Shell.Current.GoToAsync(nameof(FarmStoreDetailView));
        }

        #endregion
    }
}

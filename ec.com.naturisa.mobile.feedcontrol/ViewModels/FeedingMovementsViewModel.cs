namespace ec.com.naturisa.mobile.feedcontrol.ViewModels
{
    public partial class FeedingMovementsViewModel : BaseViewModel
    {
        [ObservableProperty]
        private ObservableCollection<FeedTransfer> feedTransfers;

        public FeedingMovementsViewModel(IToastService toastService)
            : base(toastService)
        {
            //feedTransfers = new ObservableCollection<FeedTransfer>
            //{
            //    new FeedTransfer
            //    {
            //        IdTransfer = 1,
            //        TransferCode = "75612",
            //        TotalSacks = 198,
            //        TotalWeight = 3.300,
            //        ApproximatePallets = 2,
            //        DestinationSubsidiaryId = 10,
            //        DestinationSubsidiaryName = "Maricultura",
            //        OriginSubsidiaryId = 10,
            //        OriginSubsidiaryName = "Maricultura",
            //        ReceptionDate = DateTime.Now,
            //        Status = "ASIGNADO",
            //        AssignedCarrierId = "Transportista 1",
            //        AssignedCarrierName = "NELSON ZAMBRANO",
            //        AssignedVehicleId = "Vehículo 1",
            //        AssignedVehiclePlate = "GCT 5936",
            //        Route = new Route
            //        {
            //            IsGrouped = true,
            //            Destinations = new List<Destination>
            //            {
            //                new Destination
            //                {
            //                    DestinationType = "PISCINA",
            //                    DestinationName = "MA001",
            //                    DestinationId = 101
            //                },
            //                new Destination
            //                {
            //                    DestinationType = "PISCINA",
            //                    DestinationName = "MA002",
            //                    DestinationId = 102
            //                },
            //                new Destination
            //                {
            //                    DestinationType = "PISCINA",
            //                    DestinationName = "MA003",
            //                    DestinationId = 102
            //                },
            //                new Destination
            //                {
            //                    DestinationType = "PISCINA",
            //                    DestinationName = "MA004",
            //                    DestinationId = 102
            //                }
            //            }
            //        }
            //    },
            //};
        }

        [RelayCommand]
        async Task GoToPoolFeedingByDay()
        {
            await Shell.Current.GoToAsync(nameof(PoolFeedingByDay));
        }

        [RelayCommand]
        async Task GoToReceptionOfFoodByCarrier(FeedTransfer feedTransfer)
        {
            if (feedTransfer is null)
                return;

            await Shell.Current.GoToAsync(
                nameof(ReceptionOfFoodByCarrier),
                true,
                new Dictionary<string, object> { { "FeedTransfer", feedTransfer } }
            );
        }
    }
}

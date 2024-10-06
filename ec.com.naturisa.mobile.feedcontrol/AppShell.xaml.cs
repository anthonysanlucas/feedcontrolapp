namespace ec.com.naturisa.mobile.feedcontrol
{
    public partial class AppShell : Shell
    {
        public AppShell(IToastService toastService)
        {
            InitializeComponent();
            BindingContext = new AppShellViewModel(toastService);

            Routing.RegisterRoute(nameof(LoginView), typeof(LoginView));
            Routing.RegisterRoute(nameof(FeedingPoolView), typeof(FeedingPoolView));
            Routing.RegisterRoute(nameof(FeedingPoolDetailView), typeof(FeedingPoolDetailView));
            Routing.RegisterRoute(nameof(FeedingRemainingView), typeof(FeedingRemainingView));
            Routing.RegisterRoute(
                nameof(FeedingRemainingDetailView),
                typeof(FeedingRemainingDetailView)
            );
            Routing.RegisterRoute(nameof(FarmInventoryView), typeof(FarmInventoryView));
            Routing.RegisterRoute(nameof(WallInventoryView), typeof(WallInventoryView));
            Routing.RegisterRoute(nameof(FarmStoreDetailView), typeof(FarmStoreDetailView));
            Routing.RegisterRoute(nameof(InventoryIncomeView), typeof(InventoryIncomeView));
            Routing.RegisterRoute(nameof(FeedingMovementsView), typeof(FeedingMovementsView));
            Routing.RegisterRoute(
                nameof(FeedingMovementsDetailView),
                typeof(FeedingMovementsDetailView)
            );
            Routing.RegisterRoute(
                nameof(InventoryIncomeDetailView),
                typeof(InventoryIncomeDetailView)
            );
            Routing.RegisterRoute(nameof(PoolFeedingByDay), typeof(PoolFeedingByDay));
            Routing.RegisterRoute(
                nameof(ReceptionOfFoodByCarrier),
                typeof(ReceptionOfFoodByCarrier)
            );

            #region Distribution

            Routing.RegisterRoute(nameof(FeedingPoolOneStepView), typeof(FeedingPoolOneStepView));
            Routing.RegisterRoute(nameof(FeedingPoolTwoStepView), typeof(FeedingPoolTwoStepView));
            Routing.RegisterRoute(nameof(StartOfRouteView), typeof(StartOfRouteView));
            Routing.RegisterRoute(nameof(WarehouseTransferView), typeof(WarehouseTransferView));
            Routing.RegisterRoute(nameof(PoolTransferView), typeof(PoolTransferView));
            Routing.RegisterRoute(nameof(NewTransferOneStepView), typeof(NewTransferOneStepView));
            Routing.RegisterRoute(nameof(NewTransferTwoStepView), typeof(NewTransferTwoStepView));
            Routing.RegisterRoute(
                nameof(NewTransferThreeStepView),
                typeof(NewTransferThreeStepView)
            );
            Routing.RegisterRoute(nameof(TransferDetailView), typeof(TransferDetailView));
            Routing.RegisterRoute(
                nameof(NewPoolTransferOneStepView),
                typeof(NewPoolTransferOneStepView)
            );
            Routing.RegisterRoute(
                nameof(NewPoolTransferTwoStepView),
                typeof(NewPoolTransferTwoStepView)
            );
            Routing.RegisterRoute(
                nameof(NewPoolTransferThreeStepView),
                typeof(NewPoolTransferThreeStepView)
            );

            #endregion

            #region Global
            Routing.RegisterRoute(nameof(NotificationsDetailView), typeof(NotificationsDetailView));
            Routing.RegisterRoute(nameof(SelectFarmView), typeof(SelectFarmView));
            Routing.RegisterRoute(nameof(ProfileDetailView), typeof(ProfileDetailView));
            #endregion
        }
    }
}

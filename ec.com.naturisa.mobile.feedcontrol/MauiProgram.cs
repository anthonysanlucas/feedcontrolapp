using CommunityToolkit.Maui;
using ec.com.naturisa.mobile.feedcontrol.Services.BaseHttp;
using ec.com.naturisa.mobile.feedcontrol.Services.SupplierTransferService;
using Microsoft.Extensions.Logging;

namespace ec.com.naturisa.mobile.feedcontrol
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("MaterialIcons-Regular.ttf", "GoogleMaterialFont");
                });

            #region Services
            builder.Services.AddSingleton<IAuthService, AuthService>();
            builder.Services.AddSingleton<IToastService, ToastService>();
            builder.Services.AddSingleton<BaseHttpService>();

            // SUPPLY
            builder.Services.AddSingleton<ISupplierTransferService, SupplierTransferService>();

            // DISTRIBUTION
            builder.Services.AddSingleton<IFeedTransferService, FeedTransferService>();
            #endregion

            #region ViewModels

            builder.Services.AddSingleton<InitialLoadingViewModel>();
            builder.Services.AddSingleton<LoginViewModel>();
            builder.Services.AddSingleton<FeedingPoolViewModel>();
            builder.Services.AddSingleton<FeedingPoolDetailViewModel>();
            builder.Services.AddSingleton<FeedingRemainingViewModel>();
            builder.Services.AddSingleton<FeedingRemainingDetailViewModel>();
            builder.Services.AddSingleton<FarmInventoryViewModel>();
            builder.Services.AddSingleton<WallInventoryViewModel>();
            builder.Services.AddSingleton<FarmStoreDetailViewModel>();
            builder.Services.AddSingleton<InventoryIncomeViewModel>();
            builder.Services.AddSingleton<FeedingMovementsViewModel>();

            // DISTRIBUTION
            builder.Services.AddSingleton<FeedingPoolOneStepViewModel>();
            builder.Services.AddTransient<FeedingPoolTwoStepViewModel>();
            builder.Services.AddSingleton<StartOfRouteViewModel>();
            builder.Services.AddTransient<FoodReceptionByCarrierViewModel>();
            builder.Services.AddTransient<PoolTransferViewModel>();
            builder.Services.AddTransient<InventoryReceptionViewModel>();
            builder.Services.AddTransient<NewTransferOneStepViewModel>();
            builder.Services.AddTransient<NewTransferTwoStepViewModel>();
            builder.Services.AddTransient<NewTransferThreeStepViewModel>();
            builder.Services.AddTransient<NewPoolTransferOneStepViewModel>();
            builder.Services.AddTransient<NewPoolTransferTwoStepViewModel>();
            builder.Services.AddTransient<NewPoolTransferThreeStepViewModel>();

            #endregion

            #region Views
            builder.Services.AddSingleton<NotificationsDetailView>();
            builder.Services.AddSingleton<SelectFarmView>();
            builder.Services.AddSingleton<ProfileDetailView>();

            builder.Services.AddSingleton<InitialLoadingView>();
            builder.Services.AddSingleton<LoginView>();
            builder.Services.AddSingleton<FeedingPoolView>();
            builder.Services.AddSingleton<FeedingPoolDetailView>();
            builder.Services.AddSingleton<FeedingRemainingView>();
            builder.Services.AddSingleton<FeedingRemainingDetailView>();
            builder.Services.AddSingleton<InventoryIncomeView>();
            builder.Services.AddSingleton<FarmInventoryView>();
            builder.Services.AddSingleton<WallInventoryView>();
            builder.Services.AddSingleton<FarmStoreDetailView>();
            builder.Services.AddSingleton<FeedingMovementsView>();
            builder.Services.AddSingleton<FeedingMovementsDetailView>();
            builder.Services.AddSingleton<PoolFeedingByDay>();
            builder.Services.AddSingleton<ReceptionOfFoodByCarrier>();

            // DISTRIBUTION
            builder.Services.AddSingleton<FeedingPoolOneStepView>();
            builder.Services.AddTransient<FeedingPoolTwoStepView>();
            builder.Services.AddSingleton<StartOfRouteView>();

            builder.Services.AddTransient<WarehouseTransferView>();
            builder.Services.AddTransient<WarehouseTransferViewModel>();
            builder.Services.AddTransient<TransferDetailView>();
            builder.Services.AddTransient<TransferDetailViewModel>();


            builder.Services.AddTransient<PoolTransferView>();
            builder.Services.AddTransient<InventoryReceptionView>();
            builder.Services.AddTransient<NewTransferOneStepView>();
            builder.Services.AddTransient<NewTransferTwoStepView>();
            builder.Services.AddTransient<NewTransferThreeStepView>();
            builder.Services.AddTransient<NewPoolTransferOneStepView>();
            builder.Services.AddTransient<NewPoolTransferTwoStepView>();
            builder.Services.AddTransient<NewPoolTransferThreeStepView>();
            #endregion

            #region Handlers
            FormHandler.RemoveBorders();
            #endregion

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}

using System.Reflection;

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
          
            builder.Services.AddSingleton<ISupplierTransferService, SupplierTransferService>();
          
            builder.Services.AddSingleton<IFeedTransferService, FeedTransferService>();
            builder.Services.AddSingleton<IFeedTransferDetailService, FeedTransferDetailService>();
            builder.Services.AddSingleton<IFeedTransferDetailPoolService, FeedTransferDetailPoolService>();
            builder.Services.AddSingleton<IFeedService, FeedService>();
            #endregion


            FormHandler.RemoveBorders();            

            var assembly = Assembly.GetExecutingAssembly();
            
            var views = assembly.GetTypes().Where(t => t.IsSubclassOf(typeof(ContentPage)));
            foreach (var view in views)
            {
                builder.Services.AddTransient(view);
            }

            var viewModels = assembly.GetTypes().Where(t => t.Name.EndsWith("ViewModel"));
            foreach (var viewModel in viewModels)
            {
                builder.Services.AddTransient(viewModel);
            }

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}

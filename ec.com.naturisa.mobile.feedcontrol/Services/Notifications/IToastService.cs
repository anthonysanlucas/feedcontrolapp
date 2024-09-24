namespace ec.com.naturisa.mobile.feedcontrol.Services.Notifications
{
    public interface IToastService
    {
        Task ShowToastAsync(
            string message,
            ToastDuration duration = ToastDuration.Short,
            double fontSize = 14
        );
    }
}

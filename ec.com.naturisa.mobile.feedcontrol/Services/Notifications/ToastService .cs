namespace ec.com.naturisa.mobile.feedcontrol.Services.Notifications
{
    public class ToastService : IToastService
    {
        public async Task ShowToastAsync(
            string message,
            ToastDuration duration = ToastDuration.Short,
            double fontSize = 14
        )
        {
            var toast = Toast.Make(message, duration, fontSize);
            await toast.Show();
        }
    }
}

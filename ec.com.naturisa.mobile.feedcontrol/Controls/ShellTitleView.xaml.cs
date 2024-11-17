namespace ec.com.naturisa.mobile.feedcontrol.Controls;

public partial class ShellTitleView : ContentView
{
	public ShellTitleView(ShellTitleViewModel shellTitleViewModel)
	{
		InitializeComponent();
        BindingContext = shellTitleViewModel;

        if (App.UserData != null)
            ColaboratorName.Text = $"{App.UserData.FirstNames} {App.UserData.LastNames}";

        // AvailableSubsidiaries.ItemsSource = App.Subsidiaries;
    }
}
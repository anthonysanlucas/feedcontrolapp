namespace ec.com.naturisa.mobile.feedcontrol.Controls;

public partial class ShellTitleView : ContentView
{
	public ShellTitleView(ShellTitleViewModel shellTitleViewModel)
	{
		InitializeComponent();
        BindingContext = shellTitleViewModel;        
    }
}
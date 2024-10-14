namespace ec.com.naturisa.mobile.feedcontrol.Views.Components;

public partial class EmptyView : ContentView
{
    public static readonly BindableProperty TextProperty = BindableProperty.Create(
        nameof(Text),
        typeof(string),
        typeof(EmptyView),
        string.Empty
    );

    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public EmptyView()
    {
        InitializeComponent();
        BindingContext = this;
    }
}

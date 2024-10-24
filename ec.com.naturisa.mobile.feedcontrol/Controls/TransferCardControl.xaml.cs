namespace ec.com.naturisa.mobile.feedcontrol.Controls;

public partial class TransferCardControl : ContentView
{
	public TransferCardControl()
	{
		InitializeComponent();
	}

    // Propiedades Bindable
    public static readonly BindableProperty TransferCodeProperty =
        BindableProperty.Create(nameof(TransferCode), typeof(string), typeof(TransferCardControl), string.Empty);

    public static readonly BindableProperty StatusProperty =
        BindableProperty.Create(nameof(Status), typeof(string), typeof(TransferCardControl), string.Empty);

    public static readonly BindableProperty OriginSubsidiaryNameProperty =
        BindableProperty.Create(nameof(OriginSubsidiaryName), typeof(string), typeof(TransferCardControl), string.Empty);

    public static readonly BindableProperty DestinationSubsidiaryNameProperty =
        BindableProperty.Create(nameof(DestinationSubsidiaryName), typeof(string), typeof(TransferCardControl), string.Empty);

    public static readonly BindableProperty AssignedCarrierNameProperty =
        BindableProperty.Create(nameof(AssignedCarrierName), typeof(string), typeof(TransferCardControl), string.Empty);

    public static readonly BindableProperty PrimaryUnitProperty =
        BindableProperty.Create(nameof(PrimaryUnit), typeof(int), typeof(TransferCardControl), 0);

    public static readonly BindableProperty PrimaryUnitTextProperty = BindableProperty.Create(nameof(PrimaryUnitText), typeof(string), typeof(TransferCardControl), string.Empty);

    public static readonly BindableProperty SecondaryUnitProperty =
        BindableProperty.Create(nameof(SecondaryUnit), typeof(double), typeof(TransferCardControl), 0.0);

    public static readonly BindableProperty SecondaryUnitTextProperty = BindableProperty.Create(nameof(SecondaryUnitText), typeof(string), typeof(TransferCardControl), string.Empty);
  
    public string TransferCode
    {
        get => (string)GetValue(TransferCodeProperty);
        set => SetValue(TransferCodeProperty, value);
    }

    public string Status
    {
        get => (string)GetValue(StatusProperty);
        set => SetValue(StatusProperty, value);
    }

    public string OriginSubsidiaryName
    {
        get => (string)GetValue(OriginSubsidiaryNameProperty);
        set => SetValue(OriginSubsidiaryNameProperty, value);
    }

    public string DestinationSubsidiaryName
    {
        get => (string)GetValue(DestinationSubsidiaryNameProperty);
        set => SetValue(DestinationSubsidiaryNameProperty, value);
    }

    public string AssignedCarrierName
    {
        get => (string)GetValue(AssignedCarrierNameProperty);
        set => SetValue(AssignedCarrierNameProperty, value);
    }

    public int PrimaryUnit
    {
        get => (int)GetValue(PrimaryUnitProperty);
        set => SetValue(PrimaryUnitProperty, value);
    }

    public string PrimaryUnitText
    {
        get => (string)GetValue(PrimaryUnitTextProperty);
        set => SetValue(PrimaryUnitTextProperty, value);
    }

    public double SecondaryUnit
    {
        get => (double)GetValue(SecondaryUnitProperty);
        set => SetValue(SecondaryUnitProperty, value);
    }

    public string SecondaryUnitText
    {
        get => (string)GetValue(SecondaryUnitTextProperty);
        set => SetValue(SecondaryUnitTextProperty, value);
    }
}
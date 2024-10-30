namespace ec.com.naturisa.mobile.feedcontrol.Controls;

public partial class TransferDetailHeaderControl : ContentView
{
	public TransferDetailHeaderControl()
	{
		InitializeComponent();
	}
   
    public static readonly BindableProperty TransferCodeProperty =
        BindableProperty.Create(nameof(TransferCode), typeof(string), typeof(TransferDetailHeaderControl), string.Empty);

    public string TransferCode
    {
        get => (string)GetValue(TransferCodeProperty);
        set => SetValue(TransferCodeProperty, value);
    }

    public static readonly BindableProperty StatusProperty =
        BindableProperty.Create(nameof(Status), typeof(string), typeof(TransferDetailHeaderControl), string.Empty);

    public string Status
    {
        get => (string)GetValue(StatusProperty);
        set => SetValue(StatusProperty, value);
    }

    public static readonly BindableProperty OriginSubsidiaryNameProperty =
        BindableProperty.Create(nameof(OriginSubsidiaryName), typeof(string), typeof(TransferDetailHeaderControl), string.Empty);

    public string OriginSubsidiaryName
    {
        get => (string)GetValue(OriginSubsidiaryNameProperty);
        set => SetValue(OriginSubsidiaryNameProperty, value);
    }

    public static readonly BindableProperty DestinationSubsidiaryNameProperty =
        BindableProperty.Create(nameof(DestinationSubsidiaryName), typeof(string), typeof(TransferDetailHeaderControl), string.Empty);

    public string DestinationSubsidiaryName
    {
        get => (string)GetValue(DestinationSubsidiaryNameProperty);
        set => SetValue(DestinationSubsidiaryNameProperty, value);
    }

    public static readonly BindableProperty AssignedVehiclePlateProperty =
        BindableProperty.Create(nameof(AssignedVehiclePlate), typeof(string), typeof(TransferDetailHeaderControl), string.Empty);

    public string AssignedVehiclePlate
    {
        get => (string)GetValue(AssignedVehiclePlateProperty);
        set => SetValue(AssignedVehiclePlateProperty, value);
    }

    public static readonly BindableProperty AssignedCarrierNameProperty =
        BindableProperty.Create(nameof(AssignedCarrierName), typeof(string), typeof(TransferDetailHeaderControl), string.Empty);

    public string AssignedCarrierName
    {
        get => (string)GetValue(AssignedCarrierNameProperty);
        set => SetValue(AssignedCarrierNameProperty, value);
    }
}
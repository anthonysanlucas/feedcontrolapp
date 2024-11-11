namespace ec.com.naturisa.mobile.feedcontrol.Models;

public partial class FilterStatus : ObservableObject
{
    public required string Status { get; set; }

    [ObservableProperty]
    private bool isSelected;
}

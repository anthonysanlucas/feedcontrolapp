using CommunityToolkit.Mvvm.Messaging.Messages;

namespace ec.com.naturisa.mobile.feedcontrol.Messages;

public class RefreshDataMessage : ValueChangedMessage<string>
{
    public RefreshDataMessage(string value) : base(value)
    {
    }
}

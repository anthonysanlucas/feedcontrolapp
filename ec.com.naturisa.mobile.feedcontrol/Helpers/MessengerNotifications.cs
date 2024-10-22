using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ec.com.naturisa.mobile.feedcontrol.Helpers
{
    public class RefreshDataMessenger : ValueChangedMessage<bool>
    {
        public RefreshDataMessenger(bool value) : base(value)
        {
        }
    }


}

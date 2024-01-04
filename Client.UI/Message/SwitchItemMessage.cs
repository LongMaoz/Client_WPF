using CommunityToolkit.Mvvm.Messaging.Messages;
using HandyControl.Controls;

namespace Client.UI.Message;


public class SwitchItemMessage : ValueChangedMessage<SideMenuItem>
{
    public SwitchItemMessage(SideMenuItem item) : base(item)
    {

    }
}
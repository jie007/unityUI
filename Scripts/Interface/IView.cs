using System;
using System.Collections.Generic;

public interface IView
{
    List<string> InterestNotifications();
    void OnHandlerNotification(INotification notification);
}

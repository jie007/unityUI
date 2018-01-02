using System;
using System.Collections.Generic;

public interface INotifier
{
    void SendNotification(INotification notification);
}

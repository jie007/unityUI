using System;
using System.Collections.Generic;

public interface INotification
{
    string Name { set; get; }
    object Body { set; get; }
    void Tostring();
}

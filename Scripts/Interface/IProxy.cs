using System;
using System.Collections.Generic;

public interface IProxy
{
    string ProxyName { get; }
    void RegisterView(IView view);
}

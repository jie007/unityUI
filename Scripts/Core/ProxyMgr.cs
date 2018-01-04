using System;
using System.Collections.Generic;

public class ProxyMgr : INotifier
{
    private List<Proxy> m_Proxys = new List<Proxy>();

    public IProxy RetrieveProxy(string name)
    {
        IProxy _proxy = m_Proxys.Find(proxy => proxy.ProxyName.Equals(name));
        return _proxy;
    }

    public void SendNotification(INotification notification)
    {
        m_Proxys.ForEach(proxy => proxy.SendNotification(notification));
    }
}

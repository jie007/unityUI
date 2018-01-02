using System;
using System.Collections.Generic;

public class Proxy : IProxy, INotifier
{
    protected List<IView> mViewList = new List<IView>();
    public string mProxyName = "";
    public string ProxyName
    {
        get
        {
            return mProxyName;
        }
    }

    public void RegisterView(IView view)
    {
        if (!mViewList.Contains(view))
        {
            mViewList.Add(view);
            return;
        }
        // TODO view已存在
    }

    public void OnPanelDestroy(IView view)
    {
        if (mViewList.Contains(view))
        {
            mViewList.Remove(view);
        }
    }

    private void Notify(INotification notification)
    {
        if (mViewList.Count < 1) return;

        foreach (IView view in mViewList)
        {
            var events = view.InterestNotifications();
            if (events.Contains(notification.Name))
            {
                view.OnHandlerNotification(notification);
            }
        }
    }

    public void SendNotification(INotification notification)
    {
        if (notification != null)
            Notify(notification);
    }
}

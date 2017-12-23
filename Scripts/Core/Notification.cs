using System;
using System.Collections.Generic;

public class Notification : INotification
{
    private string _name;
    private object _body;

    public Notification() { }
    public Notification(string name) { _name = name; }
    public Notification(string name, object body) { _body = body; }

    public object Body
    {
        get
        {
            return _body;
        }

        set
        {
            _body = value;
        }
    }

    public string Name
    {
        get
        {
            return _name;
        }

        set
        {
            _name = value;
        }
    }

    public void Tostring()
    {
        throw new NotImplementedException();
    }
}

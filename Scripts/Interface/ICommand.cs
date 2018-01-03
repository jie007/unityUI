using System;

public interface ICommand
{
    void Execute(INotification notification);
}


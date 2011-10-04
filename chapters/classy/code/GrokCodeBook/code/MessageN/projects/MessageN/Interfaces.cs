using System;
using System.Collections.Generic;

namespace MessageN
{
    public interface IUser
    {
        string Name {get;}
    }

    public interface IMessage
    {
        string Text {get;}
        DateTime CreationTime {get;}
        IUser From {get;}
    }
    
    public interface IDeliveryAttempt
    {
        IMessage Message {get;}
        DateTime Time {get;}
        bool Success {get;}
        string Error {get;}
    }
    
    ///<summary>
    ///Responsible for getting the message to its destination.
    ///</summary>
    public interface IMessageRouter
    {
        IMessage Message {get;}
        List<IDeliveryAttempt> Attempts {get;}
        bool Active {get;}
        void Send(IMessage message);
    }
    
    ///<summary>
    ///The communication channel for the message to be sent along.
    ///</summary>
    public interface IMessageTransport
    {
        bool InService { get; }
        void Send(IMessage message);
    }
}
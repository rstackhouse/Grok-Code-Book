using System;
using System.Collections.Generic;

namespace MessageN.Configuration
{
    public class MessageTransportConfigurationSection
    {
        private List<IMessageTransport> transports = new List<IMessageTransport>();
    
        public List<IMessageTransport> Transports
        {
            get
            {
                return transports;
            }
        }
    }
}
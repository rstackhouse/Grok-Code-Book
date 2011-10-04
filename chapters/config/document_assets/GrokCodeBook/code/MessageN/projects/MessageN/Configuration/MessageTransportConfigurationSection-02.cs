using System.Collections.Generic;

namespace MessageN.Configuration
{
    public class MessageTransportConfigurationSection
    {
        private List<IMessageTransport> transports = new List<IMessageTransport>();
    
        public int TransportCount
        {
            get
            {
                return transports.Count;
            }
        }
        
        public void Add(IMessageTransport transport)
        {
            transports.Add(transport);
        }
    }
}
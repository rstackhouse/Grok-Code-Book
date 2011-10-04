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
        
        public void ParseTransportsFromXml(XmlTag transportsTag){
            transports =
            (
                from transport 
                in transportsTag.Elements()
                .Where(tag => tag.Name != "clear")
                select CreateTransport(transport.Name)
            ).ToList<IMessageTransport>();
        }
        
        private IMessageTransport CreateTransport(string transportName)
        {
            return null;
        }
    }
}
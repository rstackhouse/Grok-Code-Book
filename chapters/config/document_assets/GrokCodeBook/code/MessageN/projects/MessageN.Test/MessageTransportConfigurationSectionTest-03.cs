using NUnit.Framework;
using NSubstitute;
using MessageN;
using MessageN.Configuration;

namespace MessagN.Test
{
    [TestFixture]
    public class MessageTransportConfigurationSectionTest
    {
        [Test]
        public void Should_Return_List_Of_Transports_From_Transports()
        {
            var transportSection = new MessageTransportConfigurationSection();
            var transport = Substitute.For<IMessageTransport>();
            transportSection.Add(transport);
			Assert.AreEqual(transportSection.TransportCount, 1);
        }
    }
}
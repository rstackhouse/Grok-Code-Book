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
        public void Should_Add_Transport()
        {
            var transportSection = new MessageTransportConfigurationSection();
            var transport = Substitute.For<IMessageTransport>();
            transportSection.Add(transport);
			Assert.AreEqual(transportSection.TransportCount, 1);
        }
    }
}
using NUnit.Framework;
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
			Assert.IsTrue(transportSection.Transports.Count > 0);
        }
    }
}
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
        public void Should_Parse_Transport_Names()
        {
            var transportSection = new MessageTransportConfigurationSection();
        
            //Arrange
            var transports = Substitute.For<XmlTag>();
            var enumerable = Substitute.For<IEnumerable<XmlTag>>();
            transports.Elements().Returns(enumerable);
            var transport = Substitute.For<XmlTag>();
            transport.Name.Returns("facebook");
            var actual = new List<XmlTag>{ transport };
            var enumerator = actual.GetEnumerator();
            enumerable.GetEnumerator().Returns(enumerator);

            //Act
            transportSection.ParseTransportsFromXml(transports);

            //Assert
            enumerable.Received().GetEnumerator();
            var name = transport.Received().Name; //Need to do assignment here to make compiler smile.
        }
        
        // Existing tests below…
    }
}
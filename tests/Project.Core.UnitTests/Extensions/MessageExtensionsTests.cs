using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Project.Core.Entities;
using Project.Core.Extensions;
using Project.Core.Models;
using VerifyXunit;
using Xunit;

namespace Project.Core.UnitTests.Extensions
{
    [UsesVerify]
    public class MessageExtensionsTests
    {
        [Fact]
        public void ToViewModel_ReturnsExpectedResult()
        {
            // Arrange
            var senderId = Guid.NewGuid();
            var recipientId = Guid.NewGuid();
            var messageId = Guid.NewGuid();
            var timestamp = new DateTime(2020, 11, 23, 16, 0, 0, 0);

            var sender = new Person
            {
                Id = senderId,
                FirstName = "John",
                LastName = "Smith"
            };

            var recipient = new Person
            {
                Id = recipientId,
                FirstName = "Jane",
                LastName = "Smith"
            };

            var message = new Message
            {
                Id = messageId,
                Timestamp = timestamp,
                Text = "Fancy having pasta for dinner?",
                Sender = senderId,
                Recipient = recipientId
            };

            var expected = new MessageViewModel
            {
                Id = messageId,
                Timestamp = timestamp,
                Text = "Fancy having pasta for dinner?",
                Sender = "John Smith",
                Recipient = "Jane Smith"
            };

            // Act
            var actual = message.ToViewModel(sender, recipient);

            // Assert
            Assert.Equal(expected.Id, actual.Id);
            Assert.Equal(expected.Timestamp, actual.Timestamp);
            Assert.Equal(expected.Text, actual.Text);
            Assert.Equal(expected.Sender, actual.Sender);
            Assert.Equal(expected.Recipient, actual.Recipient);
        }

        [Fact]
        public async Task ToViewModel_ReturnsExpectedResult_VerifyTests()
        {
            // Arrange
            var senderId = Guid.NewGuid();
            var recipientId = Guid.NewGuid();
            var messageId = Guid.NewGuid();
            var timestamp = new DateTime(2020, 11, 23, 16, 0, 0, 0);

            var sender = new Person
            {
                Id = senderId,
                FirstName = "John",
                LastName = "Smith"
            };

            var recipient = new Person
            {
                Id = recipientId,
                FirstName = "Jane",
                LastName = "Smith"
            };

            var message = new Message
            {
                Id = messageId,
                Timestamp = timestamp,
                Text = "Fancy having pasta for dinner tonight?",
                Sender = senderId,
                Recipient = recipientId
            };

            // Act
            var actual = message.ToViewModel(sender, recipient);

            // Assert
            await Verifier.Verify(actual)
                .AddExtraSettings(_ => 
                { 
                    _.DefaultValueHandling = DefaultValueHandling.Include; 
                });
        }
    }
}
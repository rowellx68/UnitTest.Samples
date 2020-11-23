using Project.Core.Entities;
using Project.Core.Models;

namespace Project.Core.Extensions
{
    public static class MessageExtensions
    {
        public static MessageViewModel ToViewModel(this Message message, Person sender, Person recipient)
        {
            return new MessageViewModel
            {
                Id = message.Id,
                Sender = $"{sender.FirstName} {sender.LastName}",
                Recipient = $"{recipient.FirstName} {recipient.LastName}",
                Text = message.Text,
                Timestamp = message.Timestamp
            };
        }
    }
}
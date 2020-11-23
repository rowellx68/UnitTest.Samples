using System;

namespace Project.Core.Entities
{
    public class Message
    {
        public Guid Id { get; set; }

        public Guid Sender { get; set; }

        public Guid Recipient { get; set; }

        public string Text { get; set; }

        public DateTime Timestamp { get; set; }
    }
}
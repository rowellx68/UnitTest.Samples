using System;

namespace Project.Core.Models
{
    public class MessageViewModel
    {
        public Guid Id { get; set; }

        public string Sender { get; set; }

        public string Recipient { get; set; }

        public string Text { get; set; }

        public DateTime Timestamp { get; set; }
    }
}
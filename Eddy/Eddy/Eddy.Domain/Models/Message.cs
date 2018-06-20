using System;
using System.Collections.Generic;
using System.Text;

namespace Eddy.Domain.Models
{
    public class Message
    {
        public int Id { get; set; }
        public ApplicationUser Sender { get; set; }
        public ApplicationUser Recipient { get; set; }
        public string Content { get; set; }
        public DateTime SentTime { get; set; }
        public bool RepliedTo { get; set; }
        public bool Hostile { get; set; }
        public bool Read { get; set; }
    }
}

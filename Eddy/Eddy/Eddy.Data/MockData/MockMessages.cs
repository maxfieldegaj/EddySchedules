using Eddy.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eddy.Data.MockData
{
    public static class MockMessages
    {
        public static List<Message> list = new List<Message>()
        {
            new Message {Id=1, Content="Tester 123", Read=true, Hostile=false, Recipient= MockEmployee.list.Find(e => e.ID == 1), Sender=MockManager.list.Find(m => m.ID == 1), RepliedTo= true, SentTime= new DateTime(2018, 01, 01, 08, 00, 00)},
            new Message {Id=2, Content="Re:Tester 123", Read=false, Hostile=false, Sender= MockEmployee.list.Find(e => e.ID == 1), Recipient=MockManager.list.Find(m => m.ID == 1), RepliedTo= true, SentTime= new DateTime(2018, 01, 01, 08, 00, 00)},
            new Message {Id=3, Content="Hostile Tester 123", Read=true, Hostile=true, Sender= MockEmployee.list.Find(e => e.ID == 4), Recipient=MockManager.list.Find(m => m.ID == 1), RepliedTo= true, SentTime= new DateTime(2018, 01, 01, 08, 00, 00)},
            new Message {Id=4, Content="Tester 123", Read=false, Hostile=false, Recipient= MockEmployee.list.Find(e => e.ID == 1), Sender=MockManager.list.Find(m => m.ID == 1), RepliedTo= true, SentTime= new DateTime(2018, 01, 01, 08, 00, 00)}
        };
    }
}

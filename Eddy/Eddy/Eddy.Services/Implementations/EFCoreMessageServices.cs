using Eddy.Data.Database;
using Eddy.Domain.Models;
using Eddy.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eddy.Services.Implementations
{
    public class EFCoreMessageServices : IMessageServices
    {
        private readonly EddyDbContext _dbContext;

        public EFCoreMessageServices(EddyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Message CreateMessage(Message newMessage)
        {
            _dbContext.SentMessages.Add(newMessage);
            _dbContext.ReceivedMessages.Add(newMessage);
            _dbContext.SaveChanges();

            return newMessage;
        }

        public bool DeleteSentMessage(int id)
        {
            var message = _dbContext.SentMessages.Find(id);

            _dbContext.DeletedMessages.Add(message);

            _dbContext.SentMessages.Remove(message);
            _dbContext.SaveChanges();
            if(message == null)
            {
                return true;
            }
            return false;
        }

        public bool DeleteReceivedMessage(int id)
        {
            var message = _dbContext.ReceivedMessages.Find(id);

            _dbContext.DeletedMessages.Add(message);

            _dbContext.ReceivedMessages.Remove(message);
            _dbContext.SaveChanges();
            if (message == null)
            {
                return true;
            }
            return false;
        }

        public List<Message> GetAllMessagesByRecipientId(string Id) => _dbContext.ReceivedMessages.Where(r => r.Recipient.Id == Id).ToList();

        public List<Message> GetAllMessagesBySenderId(string Id) => _dbContext.SentMessages.Where(s => s.Sender.Id == Id).ToList();

        public Message GetSingleMessageById(int id) => _dbContext.ReceivedMessages.Find(id);
    }
}

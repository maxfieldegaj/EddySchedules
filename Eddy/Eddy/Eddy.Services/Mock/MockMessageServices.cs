using Eddy.Data.MockData;
using Eddy.Domain.Models;
using Eddy.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eddy.Services.Mock
{
    public class MockMessageServices : IMessageServices
    {
        private List<Message> _context;

        public MockMessageServices()
        {
            _context = MockMessages.list;
        }

        public Message CreateMessage(Message newMessage)
        {
            int largestId = _context.OrderByDescending(e => e.Id).FirstOrDefault().Id;

            newMessage.Id = largestId + 1;
            _context.Add(newMessage);

            return newMessage;
        }

        public bool DeleteMessage(int id)
        {
            Message toBeDeleted = GetSingleMessageById(id);
            _context.Remove(toBeDeleted);

            toBeDeleted = GetSingleMessageById(id);
            if(toBeDeleted == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Message GetSingleMessageById(int id) => _context.Find(m => m.Id == id);

        public Message UpdateMessage(Message updatedMessage)
        {
            Message oldMsg = GetSingleMessageById(updatedMessage.Id);

            _context.Remove(oldMsg);
            _context.Add(updatedMessage);

            return updatedMessage;
        }
    }
}

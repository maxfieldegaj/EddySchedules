using Eddy.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eddy.Services.Interfaces
{
    public interface IMessageServices
    {
        // Read
        Message GetSingleMessageById(int id);

        List<Message> GetAllMessagesBySenderId(string Id);

        List<Message> GetAllMessagesByRecipientId(string Id);

        // Create
        Message CreateMessage(Message newMessage);

        // Delete
        bool DeleteSentMessage(int id);

        bool DeleteReceivedMessage(int id);

        

    }
}

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

        // Create
        Message CreateMessage(Message newMessage);

        // Update
        Message UpdateMessage(Message updatedMessage);
        // Delete
        bool DeleteMessage(int id);
    }
}

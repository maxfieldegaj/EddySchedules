using Max.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Max.Service.Interface
{
    public interface IManagerServices
    {
        // Read
        Manager GetSingleManagerById(string id);
        List<Manager> GetManagersByBusinessId(int id);

        // Create
        Manager CreateManager(Manager newManager);

        // Update
        Manager UpdateManager(Manager updatedManager);
        // Delete
        bool DeleteManager(string id);

    }
}

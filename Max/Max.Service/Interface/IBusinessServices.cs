using Eddy.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eddy.Service.Interface
{
    public interface IBusinessServices
    {
        // Read
        Business GetSingleBusinessById(int id);

        // Create
        Business CreateBusiness(Business newBusiness);

        // Update
        Business UpdateBusiness(Business updatedBusiness);
        // Delete
        bool DeleteBusiness(int id);
    }
}

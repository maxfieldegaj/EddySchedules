using Eddy.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eddy.Data.MockData
{
    public static class MockBusiness
    {
        public static List<Business> list = new List<Business>()
        {
            new Business{Id=1, Location="Austin, TX", Name="Soto", PhoneNumber="5125555555"},
            new Business{Id=2, Location="Dallas, TX", Name="KFC", PhoneNumber="5125555555"},
            new Business{Id=3, Location="Austin, TX", Name="Steakhouse", PhoneNumber="5125555555"}
        };
    }
}

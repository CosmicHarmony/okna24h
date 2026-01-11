using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace okna24h.Data.Data.CMS
{
    public enum AccessLevel
    {
        Public = 0,
        RegisteredUsers = 1,
        PremiumUsers = 2,
        Employees = 3,
        Managers = 4,
        Administrators = 5
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelApiDominykas.Auth.Model
{
    public static class UserRoles
    {
        public const string Admin = nameof(Admin);
        public const string Worker = nameof(Worker);

        public static readonly IReadOnlyCollection<string> All = new[] { Admin, Worker };
    }
}

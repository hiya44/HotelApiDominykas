using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelApiDominykas.Data.Dtos.Auth
{
    public class User : IdentityUser
    {
        [PersonalData]
        public string AditionalInfo { get; set; }
    }
}

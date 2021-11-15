using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelApiDominykas.Data.Dtos.Auth
{
    public record LoginDto(string UserName, string Password);
}

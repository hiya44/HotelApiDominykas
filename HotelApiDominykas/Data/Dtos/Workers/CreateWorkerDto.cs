using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelApiDominykas.Data.Dtos.Workers
{
    public record CreateWorkerDto(string Name, string Position, string Sector);
}

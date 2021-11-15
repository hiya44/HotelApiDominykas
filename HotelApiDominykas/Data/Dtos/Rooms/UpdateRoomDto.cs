using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelApiDominykas.Data.Dtos.Rooms
{
    public record UpdateRoomDto(bool Vacancy, string State);
}

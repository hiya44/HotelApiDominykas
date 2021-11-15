using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelApiDominykas.Data.Dtos.Rooms
{
    public record CreateRoomDto(int Number, int Size, int BedCount, bool Vacancy, string State, int HotelId);
}

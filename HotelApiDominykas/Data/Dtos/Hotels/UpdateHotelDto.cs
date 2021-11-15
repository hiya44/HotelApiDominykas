using System.ComponentModel.DataAnnotations;

namespace HotelApiDominykas.Data.Dtos.Hotels
{
    public record UpdateHotelDto([Required] string name, int RoomCount);
}

using System.ComponentModel.DataAnnotations;

namespace HotelApiDominykas.Data.Dtos.Hotels
{
    public record CreateHotelDto([Required] string Name, [Required] int RoomCount, [Required] string City);
}

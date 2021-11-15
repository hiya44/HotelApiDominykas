namespace HotelApiDominykas.Data.Dtos.Rooms
{
    public record RoomDto(int Id, int Number, int Size, int BedCount, bool Vacancy, string State);
}

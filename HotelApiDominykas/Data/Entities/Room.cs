namespace HotelApiDominykas.Data.Entities
{
    public class Room
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int Size { get; set; }
        public int BedCount { get; set; }
        public bool Vacancy { get; set; }
        public string State { get; set; }
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }
    }
}

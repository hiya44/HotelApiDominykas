using HotelApiDominykas.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelApiDominykas.Data.Repositories
{
    public interface IRoomsRepository
    {
        Task Create(Room room);
        Task Delete(Room room);
        Task<Room> Get(int id, int hotelId);
        Task<List<Room>> GetAll(int hotelId);
        Task Put(Room room);
    }

    public class RoomsRepository : IRoomsRepository
    {
        private readonly HotelApiContext _hotelApiContext;

        public RoomsRepository(HotelApiContext hotelApiContext)
        {
            _hotelApiContext = hotelApiContext;
        }

        public async Task<List<Room>> GetAll(int hotelId)
        {
            return await _hotelApiContext.Rooms.Where(o => o.HotelId == hotelId).ToListAsync();
        }
        public async Task<Room> Get(int id, int hotelId)
        {
            return await _hotelApiContext.Rooms.FirstOrDefaultAsync(o => o.Id == id && o.HotelId == hotelId);
        }
        public async Task Create(Room room)
        {
            _hotelApiContext.Rooms.Add(room);
            await _hotelApiContext.SaveChangesAsync();
        }
        public async Task Put(Room room)
        {
            _hotelApiContext.Rooms.Update(room);
            await _hotelApiContext.SaveChangesAsync();
        }
        public async Task Delete(Room room)
        {
            _hotelApiContext.Rooms.Remove(room);
            await _hotelApiContext.SaveChangesAsync();
        }
    }
}
//return new List<Room>
//{
//    new Room()
//    {
//        Id = 0,
//        Number = 100,
//        Size = 50,
//        BedCount = 1,
//        Vacancy = true,
//        State = "temp"
//    },
//    new Room()
//    {
//        Id = 1,
//        Number = 101,
//        Size = 100,
//        BedCount = 2,
//        Vacancy = true,
//        State = "temp"
//    },
//    new Room()
//    {
//        Id = 2,
//        Number = 102,
//        Size = 100,
//        BedCount = 2,
//        Vacancy = true,
//        State = "temp"
//    }
//};

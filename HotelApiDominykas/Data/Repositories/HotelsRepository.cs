using HotelApiDominykas.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelApiDominykas.Data.Repositories
{
    public interface IHotelRepository
    {
        Task Create(Hotel hotel);
        Task Delete(Hotel hotel);
        Task<Hotel> Get(int id);
        Task<List<Hotel>> GetAll();
        Task Update(Hotel hotel);
    }


    public class HotelsRepository : IHotelRepository
    {
        private readonly HotelApiContext _hotelApiContext;

        public HotelsRepository(HotelApiContext hotelApiContext)
        {
           _hotelApiContext = hotelApiContext;
        }
        public async Task<List<Hotel>> GetAll()
        {
            return await _hotelApiContext.Hotels.ToListAsync();
        }
        public async Task<Hotel> Get(int id)
        {
            return await _hotelApiContext.Hotels.FirstOrDefaultAsync(o => o.Id == id);
        }
        public async Task Create(Hotel hotel)
        {
            _hotelApiContext.Hotels.Add(hotel);
            await _hotelApiContext.SaveChangesAsync();
        }
        public async Task Update(Hotel hotel)
        {
            _hotelApiContext.Hotels.Update(hotel);
            await _hotelApiContext.SaveChangesAsync();
        }
        public async Task Delete(Hotel hotel)
        {
            _hotelApiContext.Hotels.Remove(hotel);
            await _hotelApiContext.SaveChangesAsync();
        }
    }
}
/* return new List<Hotel>
           {
               new Hotel()
               {
                   Id = 0,
                   Name = "name",
                   RoomCount = 1,
                   City = "city"
               },
               new Hotel()
               {
                   Id = 1,
                   Name = "name",
                   RoomCount = 2,
                   City = "city1"
               },
               new Hotel()
               {
                   Id = 2,
                   Name = "name",
                   RoomCount = 3,
                   City = "city2"
               }
           }; */

//return new Hotel()
//{
//    Id = 3,
//    Name = "name",
//    RoomCount = 5,
//    City = "city"
//};

//return new Hotel()
//{
//    Name = "name",
//    RoomCount = 5,
//    City = "city"
//};
//return new Hotel()
//{
//    Name = "name",
//    RoomCount = 5,
//    City = "city"
//};
using HotelApiDominykas.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelApiDominykas.Data.Repositories
{
    public interface IWorkersRepository
    {
        Task Create(Worker worker);
        Task Delete(Worker worker);
        Task<Worker> Get(int id, int hotelId);
        Task<List<Worker>> GetAll(int hotelId);
        Task Put(Worker worker);
    }

    public class WorkersRepository : IWorkersRepository
    {
        private readonly HotelApiContext _hotelApiContext;

        public WorkersRepository(HotelApiContext hotelApiContext)
        {
            _hotelApiContext = hotelApiContext;
        }
        public async Task<List<Worker>> GetAll(int hotelId)
        {
            return await _hotelApiContext.Workers.Where(o => o.HotelId == hotelId).ToListAsync();
        }
        public async Task<Worker> Get(int id, int hotelId)
        {
            return await _hotelApiContext.Workers.FirstOrDefaultAsync(o => o.Id == id && o.HotelId == hotelId);
        }
        public async Task Create(Worker worker)
        {
            _hotelApiContext.Workers.Add(worker);
            await _hotelApiContext.SaveChangesAsync();
        }
        public async Task Put(Worker worker)
        {
            _hotelApiContext.Workers.Update(worker);
            await _hotelApiContext.SaveChangesAsync();
        }
        public async Task Delete(Worker worker)
        {
            _hotelApiContext.Workers.Remove(worker);
            await _hotelApiContext.SaveChangesAsync();
        }
    }
}

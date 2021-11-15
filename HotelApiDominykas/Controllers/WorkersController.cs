using AutoMapper;
using HotelApiDominykas.Auth.Model;
using HotelApiDominykas.Data.Dtos.Workers;
using HotelApiDominykas.Data.Entities;
using HotelApiDominykas.Data.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelApiDominykas.Controllers
{
    [ApiController]
    [Route("api/hotel/{hotelId}/workers")]
    public class WorkersController : ControllerBase
    {
        private readonly IWorkersRepository _workersRepository;
        private readonly IMapper _mapper;
        private readonly IHotelRepository _hotelRepository;

        public WorkersController(IWorkersRepository workersRepository, IMapper mapper, IHotelRepository hotelRepository)
        {
            _workersRepository = workersRepository;
            _mapper = mapper;
            _hotelRepository = hotelRepository;
        }
        [HttpGet]
        public async Task<IEnumerable<WorkerDto>> GetAll(int hotelId)
        {
            return (await _workersRepository.GetAll(hotelId)).Select(o => _mapper.Map<WorkerDto>(o));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<WorkerDto>> Get(int id, int hotelId)
        {
            var worker = await _workersRepository.Get(id, hotelId);
            if (worker == null) return NotFound($"Worker with id '{id}' not found");

            return Ok(_mapper.Map<WorkerDto>(worker));
        }
        [HttpPost]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<ActionResult<WorkerDto>> Post(CreateWorkerDto workerDto, int hotelId)
        {
            var hotel = await _hotelRepository.Get(hotelId);
            if (hotel == null) return NotFound($"Hotel with id {hotelId} not found.");

            var worker = _mapper.Map<Worker>(workerDto);
            worker.HotelId = hotelId;
            await _workersRepository.Create(worker);

            return Created($"/api/hotel/{hotelId}/workers/{worker.Id}",_mapper.Map<WorkerDto>(worker));
        }
        [HttpPut("{id}")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<ActionResult<WorkerDto>> Put(int id, int hotelId, UpdateWorkerDto workerDto)
        {
            var hotel = await _hotelRepository.Get(hotelId);
            if (hotel == null) return NotFound($"Hotel with id {hotelId} not found.");

            var oldWorker = await _workersRepository.Get(id, hotelId);
            if (oldWorker == null) return NotFound($"Worker with id '{id}' not found");

            _mapper.Map(workerDto, oldWorker);
            await _workersRepository.Put(oldWorker);

            return Ok(_mapper.Map<WorkerDto>(oldWorker));
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<ActionResult<WorkerDto>> Delete(int id, int hotelId)
        {
            var hotel = await _hotelRepository.Get(hotelId);
            if (hotel == null) return NotFound($"Hotel with id {hotelId} not found.");

            var worker = await _workersRepository.Get(id, hotelId);
            if (worker == null) return NotFound($"Worker with id '{id}' not found");

            await _workersRepository.Delete(worker);

            return NoContent();
        }
    }
}

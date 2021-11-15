using AutoMapper;
using HotelApiDominykas.Auth.Model;
using HotelApiDominykas.Data.Dtos.Rooms;
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
    [Route("/api/hotel/{hotelId}/rooms")]
    public class RoomsController : ControllerBase
    {
        private readonly IRoomsRepository _roomsRepository;
        private readonly IMapper _mapper;
        private readonly IHotelRepository _hotelRepository;

        public RoomsController(IRoomsRepository roomsRepository, IMapper mapper, IHotelRepository hotelsRepository)
        {
            _roomsRepository = roomsRepository;
            _mapper = mapper;
            _hotelRepository = hotelsRepository;
        }
        [HttpGet]
        public async Task<IEnumerable<RoomDto>> GetAll(int hotelId)
        {
            return (await _roomsRepository.GetAll(hotelId)).Select(o => _mapper.Map<RoomDto>(o));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<RoomDto>> Get(int id, int hotelId)
        {
            var hotel = await _hotelRepository.Get(hotelId);
            if (hotel == null) return NotFound($"Hotel with id {hotelId} not found.");

            var room = await _roomsRepository.Get(id, hotelId);
            if (room == null) return NotFound($"Room with id {id} not found.");

            return Ok(_mapper.Map<RoomDto>(room));
        }
        [HttpPost]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<ActionResult<RoomDto>> Post(CreateRoomDto roomDto, int hotelId)
        {
            var hotel = await _hotelRepository.Get(hotelId);
            if (hotel == null) return NotFound($"Hotel with id {hotelId} not found.");

            var room = _mapper.Map<Room>(roomDto);
            room.HotelId = hotelId;
            await _roomsRepository.Create(room);

            return Created($"/api/hotel/{hotelId}/rooms/{room.Id}", _mapper.Map<RoomDto>(room));
        }
        [HttpPut("{id}")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<ActionResult<RoomDto>> Put(int id, UpdateRoomDto roomDto, int hotelId)
        {
            var hotel = await _hotelRepository.Get(hotelId);
            if (hotel == null) return NotFound($"Hotel with id {hotelId} not found.");

            var oldRoom = await _roomsRepository.Get(id, hotelId);
            if (oldRoom == null) return NotFound($"Room with id {id} not found.");
 

            _mapper.Map(roomDto, oldRoom);

            await _roomsRepository.Put(oldRoom);
            return Ok(_mapper.Map<RoomDto>(oldRoom));
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<ActionResult> Delete(int id, int hotelId)
        {
            var hotel = await _hotelRepository.Get(hotelId);
            if (hotel == null) return NotFound($"Hotel with id {hotelId} not found.");

            var room = await _roomsRepository.Get(id, hotelId);
            if (room == null) return NotFound($"Room with id {id} not found.");

            await _roomsRepository.Delete(room);
            //204
            return NoContent();
        }
    }
}

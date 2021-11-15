using HotelApiDominykas.Data.Entities;
using HotelApiDominykas.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HotelApiDominykas.Data.Dtos.Hotels;
using Microsoft.AspNetCore.Authorization;
using HotelApiDominykas.Auth.Model;

namespace HotelApiDominykas.Controllers
{
    /* 
       hotel
        /api/hotel      GETALL 200 
        /api/hotel/{id} GET 200
        /api/hotel      POST 201
        /api/hotel/{id} PUT 200
        /api/hotel/{id} DELETE 204
     
     */
    [ApiController]
    [Route("api/hotel")]
    public class HotelsController : ControllerBase
    {
        private readonly IHotelRepository _hotelRepository;
        private readonly IMapper _mapper;

        public HotelsController(IHotelRepository hotelRepository, IMapper mapper)
        {
            _hotelRepository = hotelRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IEnumerable<HotelDto>> GetAll()
        {
            return (await _hotelRepository.GetAll()).Select(o => _mapper.Map<HotelDto>(o));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<HotelDto>> Get(int id)
        {
            var hotel = await _hotelRepository.Get(id);
            if (hotel == null) return NotFound($"Hotel with id '{id}' not found.");

            return Ok(_mapper.Map<HotelDto>(hotel));
        }
        [HttpPost]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<ActionResult<HotelDto>> Post(CreateHotelDto hotelDto)
        {
            var hotel = _mapper.Map<Hotel>(hotelDto);
            await _hotelRepository.Create(hotel);

            return Created($"/api/hotel/{hotel.Id}", _mapper.Map<HotelDto>(hotel));
        }
        [HttpPut("{id}")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<ActionResult<HotelDto>> Put(int id, UpdateHotelDto hotelDto)
        {
            var hotel = await _hotelRepository.Get(id);
            if (hotel == null) return NotFound($"Hotel with id '{id}' not found.");

            //hotel.Name = hotelDto.name;
            //hotel.RoomCount = hotelDto.RoomCount;
            _mapper.Map(hotelDto, hotel);

            await _hotelRepository.Update(hotel);

            return Ok(_mapper.Map<HotelDto>(hotel));
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<ActionResult<HotelDto>> Delete(int id)
        {
            var hotel = await _hotelRepository.Get(id);
            if (hotel == null) return NotFound($"Hotel with id '{id}' not found.");

            await _hotelRepository.Delete(hotel);

            //204
            return NoContent();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HotelApiDominykas.Data.Dtos.Auth;
using HotelApiDominykas.Data.Dtos.Hotels;
using HotelApiDominykas.Data.Dtos.Rooms;
using HotelApiDominykas.Data.Dtos.Workers;
using HotelApiDominykas.Data.Entities;

namespace HotelApiDominykas.Data
{
    public class HotelApiProfile : Profile
    {
        public HotelApiProfile()
        {
            CreateMap<Hotel, HotelDto>();
            CreateMap<CreateHotelDto, Hotel>();
            CreateMap<UpdateHotelDto, Hotel>();

            CreateMap<Room, RoomDto>();
            CreateMap<CreateRoomDto, Room>();
            CreateMap<UpdateRoomDto, Room>();

            CreateMap<Worker, WorkerDto>();
            CreateMap<CreateWorkerDto, Worker>();
            CreateMap<UpdateWorkerDto, Worker>();

            CreateMap<User, UserDto>();
        }
    }
}

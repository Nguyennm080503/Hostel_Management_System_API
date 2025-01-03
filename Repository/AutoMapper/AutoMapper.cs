﻿using AutoMapper;
using Dtos.Account;
using Dtos.Hostel;
using Dtos.Measurement;
using Dtos.Room;
using Dtos.Service;
using Models;

namespace Repository.AutoMapper
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<Account, AccountDto>().ReverseMap();
            CreateMap<Account, AccountBaseDto>().ReverseMap();
            CreateMap<Account, NewBaseAccountDto>().ReverseMap();
            CreateMap<Account, NewEmployeeAccountDto>().ReverseMap();
            CreateMap<AccountDto, LoginAccountDto>();

            CreateMap<Service, ServiceDto>().ReverseMap();
            CreateMap<Service, NewServiceDto>().ReverseMap();

            CreateMap<Measurement, MeasurementDto>().ReverseMap();
            CreateMap<Measurement, NewMeasurementDto>().ReverseMap();

            CreateMap<Hostel, HostelDto>().ReverseMap();
            CreateMap<Hostel, NewHostelDto>().ReverseMap();

            CreateMap<Room, RoomDto>().ReverseMap();
            CreateMap<Room, NewRoomDto>().ReverseMap();
        }
    }
}

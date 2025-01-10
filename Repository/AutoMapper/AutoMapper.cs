using AutoMapper;
using Dtos.Account;
using Dtos.Bill;
using Dtos.Dashboard;
using Dtos.Hiring;
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

            CreateMap<ServiceHostelRoom, ServiceRoomDto>().ReverseMap();
            CreateMap<ServiceHostelRoom, NewServiceRoomDto>().ReverseMap();

            CreateMap<ServiceHostel, HostelServiceDto>().ForMember(dest => dest.ServiceHostel, opt => opt.MapFrom(src => src.ServiceHostelRoom));
            CreateMap<ServiceHostel, NewHostelServiceDto>().ReverseMap();

            CreateMap<HiringRoomHostel, HiringDto>().ReverseMap();
            CreateMap<HiringRoomHostel, CreateHiringDto>().ReverseMap();

            CreateMap<MemberHiringRoom, HiringMemberDto>().ReverseMap();
            CreateMap<MemberHiringRoom, NewHiringMemberDto>().ReverseMap();

            CreateMap<HiringService, RoomServiceDto>().ReverseMap();
            CreateMap<HiringService, RoomServiceDataDto>().ReverseMap();
            CreateMap<HiringService, NewRoomServiceDto>().ReverseMap();
            CreateMap<HiringService, RoomServiceInformationDto>().ForMember(dest => dest.ServiceRoom, opt => opt.MapFrom(src => src.ServiceHostelRoom)).AfterMap((src, dest) => {
                if (dest.ServiceRoom != null && src.ServiceLogIndices != null)
                {
                    dest.ServiceRoom.ServiceLogIndex = src.ServiceLogIndices.Select(logIndex => new ServiceLogIndexDto
                    {
                        ServiceLogIndexID = logIndex.ServiceLogIndexID,
                        ServiceRoomID = logIndex.ServiceRoomID,
                        ServiceHostelID = logIndex.ServiceHostelID,
                        ServiceLog = logIndex.ServiceLog,
                        DateCreate = logIndex.DateCreate
                    }).ToList();
                }
            });

            CreateMap<ServiceLogIndex, NewServiceLogIndexDto>().ReverseMap();
            CreateMap<ServiceLogIndex, ServiceLogIndexDto>().ReverseMap();

            CreateMap<BillPayment, BillDto>().ForMember(dest => dest.Details, opt => opt.MapFrom(src => src.BillInformation)).ForMember(dest => dest.Hiring, opt => opt.MapFrom(src => src.HiringRoomHostel));
            CreateMap<BillPayment, NewBillDto>().ReverseMap();
            CreateMap<BillPayment, NewBillPayDto>().ReverseMap();
            CreateMap<BillPayment, DashboardPaymentDto>().ReverseMap();

            CreateMap<BillInformation, BillDetailDto>().ReverseMap();
            CreateMap<BillInformation, NewBillDetailDto>().ReverseMap();
        }
    }
}

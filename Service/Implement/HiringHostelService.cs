using Common.Enum;
using Dtos.Hiring;
using Dtos.Service;
using Repository.Interface;
using Service.Exception;
using Service.Interface;

namespace Service.Implement
{
    public class HiringHostelService : IHiringHostelService
    {
        private readonly IHiringHostelRepository _hiringHostelRepository;
        private readonly IRoomRepository _roomRepository;
        private readonly IHostelRepository _hostelRepository;
        private readonly IMemberHiringRepository _memberHiringRepository;
        private readonly IServiceRoomRepository _serviceRoomRepository;

        public HiringHostelService(IHiringHostelRepository hiringHostelRepository, IRoomRepository roomRepository, IHostelRepository hostelRepository, IMemberHiringRepository memberHiringRepository, IServiceRoomRepository serviceRoomRepository)
        {
            _hiringHostelRepository = hiringHostelRepository;
            _roomRepository = roomRepository;
            _hostelRepository = hostelRepository;
            _memberHiringRepository = memberHiringRepository;
            _serviceRoomRepository = serviceRoomRepository;
        }

        public async Task CreateHiringHostel(CreateHiringDto hiringDto, int accountId)
        {
            if(hiringDto.HiringType == 1 || hiringDto.HiringType == 3)
            {
                var room = await _roomRepository.GetRoomByID(hiringDto.RoomID);
                if (room.Status == RoomStatusEnum.Hiring.ToString())
                {
                    throw new ServiceException("Phòng này đang được thuê không thể tạo yêu cầu!");
                }
                else
                {
                    await _hiringHostelRepository.CreateHiringHostel(hiringDto, accountId);
                    var hiring = await _hiringHostelRepository.GetHiringCurrent(hiringDto.RoomID);
                    var member = new NewHiringMemberDto{
                        HiringRoomHostelID = hiring.HiringRoomHostelID,
                        MemberHiringName = hiring.AccountHiringName,
                        Address = hiring.AccountHiringAddress,
                        CitizenCard = hiring.AccountHiringCitizen,
                        Phone = hiring.AccountHiringPhone
                    };
                    foreach(var service in hiringDto.ServiceRooms)
                    {
                        var hiringService = new RoomServiceDto
                        {
                            HiringRoomHostelID = hiring.HiringRoomHostelID,
                            ServiceHostelRoomID = service.ServiceHostelRoomID,
                        };
                        await _serviceRoomRepository.AddNewServiceHiring(hiringService);
                        var serviceCur =  await _serviceRoomRepository.GetServiceByCurrent(hiringService.ServiceHostelRoomID, hiringService.HiringRoomHostelID);
                        if(hiringDto.HiringType == 1 && service.NewServiceLogIndexDto.ServiceLog != 0)
                        {
                            var indexLog = new NewServiceLogIndexDto
                            {
                                ServiceHostelID = serviceCur.HiringServiceID,
                                ServiceLog = service.NewServiceLogIndexDto.ServiceLog,
                                ServiceRoomID = serviceCur.HiringServiceID,
                            };
                            await _hiringHostelRepository.CreateServiceLogIndex(indexLog);
                        }
                    }
                    await _memberHiringRepository.CreateNewMember(member);
                    await _roomRepository.UpdateRoomHiring(hiringDto.RoomID);
                }
            }
            else
            {
                var hostel = await _hostelRepository.GetHostelByID(hiringDto.HostelID);
                if(hostel.Status == HostelStatusEnum.Hiring.ToString())
                {
                    throw new ServiceException("Nhà này đang được thuê không thể tạo yêu cầu");
                }
                else
                {
                    await _hiringHostelRepository.CreateHiringHostel(hiringDto, accountId);
                    await _hostelRepository.UpdateHostelHiring(hiringDto.HostelID);
                }
            }

            return;
        }

        public async Task<IEnumerable<HiringDto>> GetAllHiringsHistory(int roomId)
        {
            return await _hiringHostelRepository.GetAllHiringsHistory(roomId);
        }

        public async Task<HiringInformationDto> GetHiringCurrent(int roomId)
        {
            var hiringInf = await _hiringHostelRepository.GetHiringCurrent(roomId);
            IEnumerable<HiringMemberDto> members = Enumerable.Empty<HiringMemberDto>();
            IEnumerable<RoomServiceInformationDto> services = Enumerable.Empty<RoomServiceInformationDto>();
            if (hiringInf != null)
            {
                members = await _memberHiringRepository.GetAllMembers(hiringInf.HiringRoomHostelID);
                services = await _serviceRoomRepository.GetAllServiceOfRoom(hiringInf.HiringRoomHostelID);
            }

            return new HiringInformationDto
            {
                HiringInformation = hiringInf,
                Members = members,
                ServiceRooms = services,
            };
        }
    }
}

using AutoMapper;
using Dtos.Room;
using Repository.Interface;
using Service.Exception;
using Service.Interface;

namespace Service.Implement
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IMapper _mapper;

        public RoomService(
           IRoomRepository roomRepository,
           IMapper mapper)
        {
            _roomRepository = roomRepository;
            _mapper = mapper;
        }
        public async Task AddNewRoom(NewRoomDto roomDto)
        {
            var room = await _roomRepository.GetRoomByName(roomDto.RoomName, roomDto.HostelID);

            if (room != null)
            {
                throw new ServiceException("Phòng này đã tồn tại trong nhà này !");
            }
            await _roomRepository.AddNewRoom(roomDto);
            return;
        }

        public async Task<HostelRoomDto> GetAllRoomsOfHostel(int hostelId)
        {
            return await _roomRepository.GetAllRoomsOfHostel(hostelId);
        }
    }
}

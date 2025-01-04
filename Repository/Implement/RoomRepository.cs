using AutoMapper;
using Common.Enum;
using Dao;
using Dtos.Hostel;
using Dtos.Room;
using Models;
using Repository.Interface;

namespace Repository.Implement
{
    public class RoomRepository : IRoomRepository
    {
        private readonly IMapper _mapper;
        public RoomRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task AddNewRoom(NewRoomDto roomDto)
        {
            var room = _mapper.Map<Room>(roomDto);
            room.RoomName = roomDto.RoomName;
            room.Capacity = roomDto.Capacity;
            room.Width = roomDto.Width;
            room.Lenght = roomDto.Lenght;
            room.HostelID = roomDto.HostelID;
            room.Status = RoomStatusEnum.New.ToString();
            room.Area = roomDto.Area;
            room.DateCreate = DateTime.Now;
            await RoomDao.Instance.CreateAsync(room);

            return;
        }

        public async Task DeleteRoom(int roomId)
        {
            var room = await RoomDao.Instance.GetRoomID(roomId);
            room.Status = RoomStatusEnum.Deleted.ToString();

            await RoomDao.Instance.UpdateAsync(room);
        }

        public async Task<HostelRoomDto> GetAllRoomsOfHostel(int hostelId)
        {
            var rooms = await RoomDao.Instance.GetAllRoomOfHostel(hostelId);
            var hostel = await HostelDao.Instance.GetHostelID(hostelId);

            var roomsMap = _mapper.Map<IEnumerable<RoomDto>>(rooms);
            var hostelMap = _mapper.Map<HostelDto>(hostel);

            return new HostelRoomDto
            {
                Rooms = roomsMap,
                Hostel = hostelMap
            };
        }

        public async Task<RoomDto> GetRoomByID(int roomID)
        {
            var room = await RoomDao.Instance.GetRoomID(roomID);
            return _mapper.Map<RoomDto>(room);
        }

        public async Task<RoomDto> GetRoomByName(string roomName, int hostelId)
        {
            var room = await RoomDao.Instance.GetRoomName(roomName, hostelId);
            return _mapper.Map<RoomDto>(room);
        }

        public async Task UpdateRoom(UpdateRoomDto roomDto)
        {
            var room = await RoomDao.Instance.GetRoomID(roomDto.RoomID);
            room.RoomFee = roomDto.RoomFee;
            room.RoomName = roomDto.RoomName;
            room.Capacity = roomDto.Capacity;

            await RoomDao.Instance.UpdateAsync(room);
        }
    }
}

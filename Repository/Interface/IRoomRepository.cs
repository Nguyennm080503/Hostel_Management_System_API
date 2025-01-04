using Dtos.Room;

namespace Repository.Interface
{
    public interface IRoomRepository
    {
        Task<HostelRoomDto> GetAllRoomsOfHostel(int hostelId);
        Task AddNewRoom(NewRoomDto roomDto);
        Task<RoomDto> GetRoomByName(string roomName, int hostelId);
        Task<RoomDto> GetRoomByID(int roomID);
        Task DeleteRoom(int roomId);
        Task UpdateRoom(UpdateRoomDto roomDto);
    }
}

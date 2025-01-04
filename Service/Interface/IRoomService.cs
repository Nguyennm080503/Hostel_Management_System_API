using Dtos.Room;

namespace Service.Interface
{
    public interface IRoomService
    {
        Task<HostelRoomDto> GetAllRoomsOfHostel(int hostelId);
        Task AddNewRoom(NewRoomDto roomDto);
        Task<RoomDto> GetRoomDetail(int roomId);
        Task DeleteRoom(int roomId);
        Task UpdateRoom(UpdateRoomDto roomDto);
    }
}

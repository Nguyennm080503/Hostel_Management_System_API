using Dtos.Room;

namespace Service.Interface
{
    public interface IRoomService
    {
        Task<HostelRoomDto> GetAllRoomsOfHostel(int hostelId);
        Task AddNewRoom(NewRoomDto roomDto);
    }
}

using OneOf;

public class RoomService : IRoomService
{
    public Task<OneOf<ResponseRoomRegisterSuccess, Error>> RegisterRoom(RoomRegisterDto roomRegisterDto)
    {
        throw new NotImplementedException();
    }
}
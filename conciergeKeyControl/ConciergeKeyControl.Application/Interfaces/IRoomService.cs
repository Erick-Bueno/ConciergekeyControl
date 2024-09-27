using OneOf;

public interface IRoomService{
    public Task<OneOf<ResponseRoomRegisterSuccess, Error>> RegisterRoom(RoomRegisterDto roomRegisterDto);
}
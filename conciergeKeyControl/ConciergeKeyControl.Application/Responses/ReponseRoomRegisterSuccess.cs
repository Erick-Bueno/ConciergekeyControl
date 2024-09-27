public class ResponseRoomRegisterSuccess{
    public int Status { get; set; }
    public string Message { get; set; }

    public ResponseRoomRegisterSuccess(int status, string message) {
        Status = status;
        Message = message;
    }
    
}
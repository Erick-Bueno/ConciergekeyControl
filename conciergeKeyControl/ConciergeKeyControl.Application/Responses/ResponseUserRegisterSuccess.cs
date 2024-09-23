public class ResponseUserRegisterSuccess{
    public int Status { get; set; }
    public string Message { get; set; }

    public ResponseUserRegisterSuccess(int status, string message) {
        Status = status;
        Message = message;
    }
    
}
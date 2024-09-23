using OneOf;

public interface IAuhtService{
    public Task<OneOf<ResponseUserRegisterSuccess, Error>> Register(UserRegisterDto userRegisterDto);
}
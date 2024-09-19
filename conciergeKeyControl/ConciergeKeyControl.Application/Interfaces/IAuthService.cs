using OneOf;

public interface IAuhtService{
    public Task<OneOf<Error, ResponseUserRegisterSuccess>> Register(UserRegisterDto userRegisterDto);
}
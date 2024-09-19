using OneOf;

public class AuthService : IAuhtService{
    public Task<OneOf<Error, ResponseUserRegisterSuccess>> Register(UserRegisterDto userRegisterDto){
        throw new NotImplementedException();
    }
}
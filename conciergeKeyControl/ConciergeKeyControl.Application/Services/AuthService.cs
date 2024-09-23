using OneOf;
using Microsoft.Extensions.Configuration;
public class AuthService : IAuhtService{
    private readonly IUserRepository _UserRepository;
    private readonly IConfiguration _Configuration;
    private readonly IAes256 _Aes256;

    public AuthService(IUserRepository userRepository, IAes256 aes256)
    {
        _UserRepository = userRepository;
        _Aes256 = aes256;
    }

    public async Task<OneOf<Error, ResponseUserRegisterSuccess>> Register(UserRegisterDto userRegisterDto){
        try
        {
            var user = _UserRepository.FindUserByEmail(userRegisterDto.Email);
            if(user is not null){
                return new EmailAlreadyRegistered("Email ja cadastrado");
            }
            var key = _Configuration.GetValue<string>("keyCrypt");
            var encryptPassword = _Aes256.Encrypt(userRegisterDto.Password, key, out string iv );
            var newUser = UserMapper.ToEntity(userRegisterDto, iv);
            await _UserRepository.CreateUser(newUser);
            return new ResponseUserRegisterSuccess(201, "Usuário cadastrado com sucesso");
        }
        catch (Exception ex)
        {
            return new InternalServerError(ex.Message);
        }
    }
}
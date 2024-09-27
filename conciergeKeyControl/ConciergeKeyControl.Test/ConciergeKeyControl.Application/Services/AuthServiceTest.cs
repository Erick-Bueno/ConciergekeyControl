using Microsoft.Extensions.Configuration;
using Moq;
using Xunit;

public class AuthServiceTest{
    [Fact]
    public async void Register_EmailAlreadyRegistered_ReturnEmailAlreadyRegisteredError(){
        var userRepositoryMock = new Mock<IUserRepository>();
        var configuration = new ConfigurationBuilder()
        .Build();
        var aes256Mock = new Mock<IAes256>();

        var user = new User()
        .SetEmail("erickjb93@gmail.com");
        var userRegisterDto = new UserRegisterDto(){
            Email = "erickjb93@gmail.com"
        };

        userRepositoryMock.Setup(ur => ur.FindUserByEmail(user.Email)).Returns(user);
        
        var authService = new AuthService(userRepositoryMock.Object, aes256Mock.Object, configuration);
        var response = new EmailAlreadyRegistered("Email ja cadastrado");
        var result = await authService.Register(userRegisterDto);
        Assert.Equal(response.TypeError, result.AsT1.TypeError);
        Assert.Equal(response.ErrorCodeName, result.AsT1.ErrorCodeName);
    }
    [Fact]
    public async void Register_UserRegisterSuccess_ReturnUserRegisterSuccess(){
        var userRepositoryMock = new Mock<IUserRepository>();
        var appSettingsJson = new Dictionary<string, string>{
            {"keyCrypt", "PUkgZLxWoFiKRPMS+Gp/vJL+7ey4WkNZpcoBPOkjlWA="}
        };
        var configuration = new ConfigurationBuilder()
        .AddInMemoryCollection(appSettingsJson)
        .Build();
        var aes256Mock = new Mock<IAes256>();
        
        var user = new User()
        .SetEmail("erickjb93@gmail.com");
        var userRegisterDto = new UserRegisterDto(){
            Email = "erickjb93@gmail.com",
            Password = "Sirlei231@"
        };
        var encryptPassword = "kkdddkkdd";
        string iv = "teste";
        var newUser = UserMapper.ToEntity(userRegisterDto, iv);
        userRepositoryMock.Setup(ur => ur.FindUserByEmail(user.Email)).Returns((User)null);
        aes256Mock.Setup(ae => ae.Encrypt(userRegisterDto.Password,  appSettingsJson["keyCrypt"], out iv)).Returns(encryptPassword);
        userRepositoryMock.Setup(ur => ur.CreateUser(newUser));
        var authService = new AuthService(userRepositoryMock.Object, aes256Mock.Object, configuration);
        var response = new ResponseUserRegisterSuccess(201, "Usuário cadastrado com sucesso");
        var result = await authService.Register(userRegisterDto);
        Assert.Equal(response.Message, result.AsT0.Message);
        Assert.Equal(response.Status, result.AsT0.Status);

    }
}
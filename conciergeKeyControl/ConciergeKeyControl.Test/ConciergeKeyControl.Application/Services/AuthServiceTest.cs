using Bogus;
using Microsoft.Extensions.Configuration;
using Moq;
using Xunit;

public class AuthServiceTest
{
    private readonly Faker _faker = new Faker();
    [Fact]
    public async void Register_EmailAlreadyRegistered_ReturnEmailAlreadyRegisteredError(){
        //act
        var userRepositoryMock = new Mock<IUserRepository>();
        var configuration = new ConfigurationBuilder()
        .Build();
        var aes256Mock = new Mock<IAes256>();
        var email = _faker.Person.Email;
        var user = new User()
        .SetEmail(email);
        var userRegisterDto = new Faker<UserRegisterDto>().StrictMode(true)
            .RuleFor(x => x.Email, email)
            .RuleFor(x => x.Password,
                f => f.Internet.Password())
            .RuleFor(x => x.Name, f => f.Name.FullName());

        userRepositoryMock.Setup(ur => ur.FindUserByEmail(user.Email)).Returns(user);
        
        var authService = new AuthService(userRepositoryMock.Object, aes256Mock.Object, configuration);
        var response = new EmailAlreadyRegistered("Email ja cadastrado");
        //act
        var result = await authService.Register(userRegisterDto);
        Assert.Equal(response.TypeError, result.AsT1.TypeError);
        //assert
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
        var email = _faker.Person.Email;
        var user = new User()
        .SetEmail(email);
        var userRegisterDtoFaker = new Faker<UserRegisterDto>().StrictMode(true)
            .RuleFor(x => x.Email, email)
            .RuleFor(x => x.Password,
                f => f.Internet.Password())
            .RuleFor(x => x.Name, f => f.Name.FullName());
        var userRegisterDto = userRegisterDtoFaker.Generate();
        var encryptPassword = _faker.Random.Hash();
        string iv = _faker.Random.String();
        var newUser = UserMapper.ToEntity(userRegisterDto, iv);
        userRepositoryMock.Setup(ur => ur.FindUserByEmail(user.Email)).Returns((User)null);
        aes256Mock.Setup(ae => ae.Encrypt(userRegisterDto.Password,appSettingsJson["keyCrypt"], out iv)).Returns(encryptPassword);
        userRepositoryMock.Setup(ur => ur.CreateUser(newUser));
        var authService = new AuthService(userRepositoryMock.Object, aes256Mock.Object, configuration);
        var response = new ResponseUserRegisterSuccess(201, "Usuário cadastrado com sucesso");
        var result = await authService.Register(userRegisterDto);
        Assert.Equal(response.Message, result.AsT0.Message);
        Assert.Equal(response.Status, result.AsT0.Status);

    }
}
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
        Assert.Equal(response, result);
    }
}
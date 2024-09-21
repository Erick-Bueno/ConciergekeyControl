public class UserMapper
{
    public static User ToEntity(UserRegisterDto userRegisterDto, string iv){
        var user = new User()
        .SetEmail(userRegisterDto.Email)
        .SetName(userRegisterDto.Name)
        .SetPassword(userRegisterDto.Password)
        .SetIv(iv);
        return user;
    }
}
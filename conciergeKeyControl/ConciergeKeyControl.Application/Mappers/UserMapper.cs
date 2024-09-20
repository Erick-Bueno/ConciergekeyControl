public class UserMapper
{
    public static User ToEntity(UserRegisterDto userRegisterDto, string iv){
        var user = new User()
        .setEmail(userRegisterDto.Email)
        .setName(userRegisterDto.Name)
        .setPassword(userRegisterDto.Password)
        .setIv(iv);
        return user;
    }
}
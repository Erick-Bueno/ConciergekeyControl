public class UserMapper
{
    public static User ToEntity(UserRegisterDto userRegisterDto, string iv){
        var user = new User()
        .setEmail(userRegisterDto.email)
        .setName(userRegisterDto.name)
        .setPassword(userRegisterDto.password)
        .setIv(iv);
        return user;
    }
}
using System.Diagnostics.Contracts;

public interface IUserRepository{
    public User FindUserByEmail(string email);
    public Task CreateUser(User user);
}
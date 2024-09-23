
public class UserRepository : IUserRepository
{
    private readonly AppDbContext _AppDbContext;

    public UserRepository(AppDbContext appDbContext)
    {
        _AppDbContext = appDbContext;
    }

    public async Task<User> CreateUser(User user)
    {
        await _AppDbContext.users.AddAsync(user);
        await _AppDbContext.SaveChangesAsync();
        return user;
    }

    public User FindUserByEmail(string email)
    {
        return _AppDbContext.users.Where(u => u.Email == email).SingleOrDefault();
    }
}
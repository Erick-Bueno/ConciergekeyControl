public class UserRepository : IUserRepository
{
    private readonly AppDbContext _appDbContext;

    public UserRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public User FindUserByEmail(string email)
    {
        return _appDbContext.users.Where(u => u.email == email).SingleOrDefault();
    }
}
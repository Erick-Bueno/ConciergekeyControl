public class UserRepository : IUserRepository
{
    private readonly AppDbContext _AppDbContext;

    public UserRepository(AppDbContext appDbContext)
    {
        _AppDbContext = appDbContext;
    }

    public User FindUserByEmail(string email)
    {
        return _AppDbContext.users.Where(u => u.Email == email).SingleOrDefault();
    }
}
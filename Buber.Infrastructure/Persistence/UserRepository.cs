using Buber.Application.Common.Interfaces.Persistence;
using Buber.Domain.Entities;

namespace Buber.Infrastructure.Persistence;

public class UserRepository : IUserRepository
{
    private static readonly List<User> users = new();
    public void AddUser(User user)
    {
        users.Add(user);
    }

    public User? GetuserByEmail(string email)
    {
        return users.SingleOrDefault(x=>x.Email == email);
    }
}
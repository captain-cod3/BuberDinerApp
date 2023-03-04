using Buber.Domain.Entities;

namespace Buber.Application.Common.Interfaces.Persistence;

public interface IUserRepository{
    User? GetuserByEmail(string email);
    void AddUser(User user);
}
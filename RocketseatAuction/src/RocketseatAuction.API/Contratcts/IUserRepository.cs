using RocketseatAuction.API.Entities;

namespace RocketseatAuction.API.Contratcts;

public interface IUserRepository
{
    bool ExistUserWithEmail(string email);
    User GetUserByEmail(string email);
}

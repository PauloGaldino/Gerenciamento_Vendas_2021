using Domain.Interfaces.Persons.UserManager;
using Entity.Persons.Identity.Users.UsersManager;
using Infrastructure.Repositories.Generics;

namespace Infrastructure.Repositories.Persons.UserManager
{
    public class AccessUserTypeRepository : GenericRepository<AccessTypeUser>, IAccessUserType
    {
    }
}

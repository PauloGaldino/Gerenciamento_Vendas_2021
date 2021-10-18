using Application.Interfaces.Persons.UserManager;
using Domain.Interfaces.Persons.UserManager;
using Entity.Persons.Identity.Users.UsersManager;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.OpenApps.Persons.ManagerUsers
{
    public class AccesUserTypeApp : IAccessTypeUserApp
    {
        IAccessUserType _accessUserType;
        public AccesUserTypeApp(IAccessUserType accessUserType)
        {
            _accessUserType = accessUserType;
        }

        public async Task Add(AccessTypeUser accessType)
        {
            await _accessUserType.Add(accessType);
        }

        public async Task Delete(AccessTypeUser accessType)
        {
            await _accessUserType.Delete(accessType);
        }
        public async Task Update(AccessTypeUser accessType)
        {
            await _accessUserType.UpDate(accessType);
        }
        public async Task<AccessTypeUser> GetEntityById(int Id)
        {
            return await _accessUserType.getEntityById(Id);
        }

        public async Task<List<AccessTypeUser>> List()
        {
            return await _accessUserType.List();
        }


    }
}

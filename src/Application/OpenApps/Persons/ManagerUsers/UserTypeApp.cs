using Application.Interfaces.Persons.UserManager;
using Domain.Interfaces.Persons.UserManager;
using Entity.Persons.Identity.Users.UsersManager;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.OpenApps.Persons.ManagerUsers
{
    public class UserTypeApp : IUserTypeApp
    {
        private readonly IUserType _user;
        public UserTypeApp(IUserType user)
        {
            _user = user;
        }
        public async Task Add(UserType Object)
        {
            await _user.Add(Object);
        }

        public async Task Delete(UserType Object)
        {
            await _user.Delete(Object);
        }
        public async Task Update(UserType Object)
        {
            await _user.UpDate(Object);
        }
        public async Task<UserType> GetEntityById(int Id)
        {
            return await _user.getEntityById(Id);
        }

        public async Task<List<UserType>> List()
        {
            return await _user.List();
        }


    }
}

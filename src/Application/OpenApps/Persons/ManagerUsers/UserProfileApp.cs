using Application.Interfaces.Persons.UserManager;
using Domain.Interfaces.Persons.UserManager;
using Entity.Persons.Identity.Users.UsersManager;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.OpenApps.Persons.ManagerUsers
{
    public class UserProfileApp : IUserProfileApp
    {
        private readonly IUserProfile _userProfile;
        public UserProfileApp(IUserProfile userProfile)
        {
            _userProfile = userProfile;
        }
        public async Task Add(UserProfile userProfile)
        {
            await _userProfile.Add(userProfile);
        }

        public async Task Delete(UserProfile userProfile)
        {
            await _userProfile.Delete(userProfile);
        }
        public async Task Update(UserProfile userProfile)
        {
            await _userProfile.UpDate(userProfile);
        }

        public async Task<UserProfile> GetEntityById(int Id)
        {
            return await _userProfile.getEntityById(Id);
        }

        public async Task<List<UserProfile>> List()
        {
            return await _userProfile.List();
        }


    }
}

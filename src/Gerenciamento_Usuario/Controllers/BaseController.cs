using Gerenciamento_Usuario.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gerenciamento_Usuario.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        public async Task<bool> UserAuthorizedAccess(int pageCod, ApplicationDbContext _context)
        {
            var userAuthorize = User.Identity.Name;

            var authorize = await (from tu in _context.UserTypes // tabela UserType
                                   join atu in _context.AccessUserTypes on tu.Id equals atu.UserTypeId // liga as tebleas userType com a tabela AccessTypeUSer
                                   join up in _context.UserProfiles on tu.Id equals up.UserTypeId // Liga as tabela UserType com a tabela UserProfile
                                   join us in _context.User on up.UserId equals us.Id // Liga as tabelas UserProfile com a tabela User
                                   where atu.Id == pageCod && us.Email == userAuthorize

                                   select new
                                   {
                                       tu.Id,
                                   }).AnyAsync();
            return authorize;
        }
    }
}

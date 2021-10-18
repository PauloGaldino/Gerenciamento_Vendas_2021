using Entity.Persons.Identity.Users.UsersManager;
using Infrastructure.Configurations.Contexts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Gerenciamento_Vendas.UI.Web.Controllers
{
    [Authorize]
    public class AccessTypeUsersController : Controller
    {
        private readonly BaseDbContext _context;

        public AccessTypeUsersController(BaseDbContext context)
        {
            _context = context;
        }

        // GET: AccessTypeUsers
        public async Task<IActionResult> Index()
        {
            var baseDbContext = _context.AccessTypeUsers.Include(a => a.UserType);
            return View(await baseDbContext.ToListAsync());
        }

        // GET: AccessTypeUsers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accessTypeUser = await _context.AccessTypeUsers
                .Include(a => a.UserType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (accessTypeUser == null)
            {
                return NotFound();
            }

            return View(accessTypeUser);
        }

        // GET: AccessTypeUsers/Create
        public IActionResult Create()
        {
            ViewData["UserTypeId"] = new SelectList(_context.UserTypes, "Id", "NameUserType");
            return View();
        }

        // POST: AccessTypeUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FunctionalityName,UserTypeId")] AccessTypeUser accessTypeUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(accessTypeUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserTypeId"] = new SelectList(_context.UserTypes, "Id", "NameUserType", accessTypeUser.UserTypeId);
            return View(accessTypeUser);
        }

        // GET: AccessTypeUsers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accessTypeUser = await _context.AccessTypeUsers.FindAsync(id);
            if (accessTypeUser == null)
            {
                return NotFound();
            }
            ViewData["UserTypeId"] = new SelectList(_context.UserTypes, "Id", "NameUserType", accessTypeUser.UserTypeId);
            return View(accessTypeUser);
        }

        // POST: AccessTypeUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FunctionalityName,UserTypeId")] AccessTypeUser accessTypeUser)
        {
            if (id != accessTypeUser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(accessTypeUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccessTypeUserExists(accessTypeUser.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserTypeId"] = new SelectList(_context.UserTypes, "Id", "NameUserType", accessTypeUser.UserTypeId);
            return View(accessTypeUser);
        }

        // GET: AccessTypeUsers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accessTypeUser = await _context.AccessTypeUsers
                .Include(a => a.UserType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (accessTypeUser == null)
            {
                return NotFound();
            }

            return View(accessTypeUser);
        }

        // POST: AccessTypeUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var accessTypeUser = await _context.AccessTypeUsers.FindAsync(id);
            _context.AccessTypeUsers.Remove(accessTypeUser);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AccessTypeUserExists(int id)
        {
            return _context.AccessTypeUsers.Any(e => e.Id == id);
        }
    }
}

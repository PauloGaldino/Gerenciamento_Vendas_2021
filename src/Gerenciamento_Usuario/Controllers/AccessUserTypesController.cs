using Gerenciamento_Usuario.Data;
using Gerenciamento_Usuario.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Gerenciamento_Usuario.Controllers
{
    public class AccessUserTypesController : BaseController
    {
        private readonly ApplicationDbContext _context;

        public AccessUserTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AccessUserTypes
        public async Task<IActionResult> Index()
        {
            var authorizeAccess = await UserAuthorizedAccess(1, _context);

            if (!authorizeAccess)
            {
                return RedirectToAction("Index", "Home");
            }

            var applicationDbContext = _context.AccessUserTypes.Include(a => a.UserType);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: AccessUserTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accessUserType = await _context.AccessUserTypes
                .Include(a => a.UserType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (accessUserType == null)
            {
                return NotFound();
            }

            return View(accessUserType);
        }

        // GET: AccessUserTypes/Create
        public IActionResult Create()
        {
            ViewData["UserTypeId"] = new SelectList(_context.UserTypes, "Id", "NameUserType");
            return View();
        }

        // POST: AccessUserTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FunctionalityName,UserTypeId")] AccessUserType accessUserType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(accessUserType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserTypeId"] = new SelectList(_context.UserTypes, "Id", "NameUserType", accessUserType.UserTypeId);
            return View(accessUserType);
        }


        // GET: AccessUserTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accessUserType = await _context.AccessUserTypes.FindAsync(id);
            if (accessUserType == null)
            {
                return NotFound();
            }
            ViewData["UserTypeId"] = new SelectList(_context.UserTypes, "Id", "NameUserType", accessUserType.UserTypeId);
            return View(accessUserType);
        }

        // POST: AccessUserTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FunctionalityName,UserTypeId")] AccessUserType accessUserType)
        {
            if (id != accessUserType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(accessUserType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccessUserTypeExists(accessUserType.Id))
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
            ViewData["UserTypeId"] = new SelectList(_context.UserTypes, "Id", "NameUserType", accessUserType.UserTypeId);
            return View(accessUserType);
        }



        // GET: AccessUserTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accessUserType = await _context.AccessUserTypes
                .Include(a => a.UserType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (accessUserType == null)
            {
                return NotFound();
            }

            return View(accessUserType);
        }

        // POST: AccessUserTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var accessUserType = await _context.AccessUserTypes.FindAsync(id);
            _context.AccessUserTypes.Remove(accessUserType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AccessUserTypeExists(int id)
        {
            return _context.AccessUserTypes.Any(e => e.Id == id);
        }
    }
}

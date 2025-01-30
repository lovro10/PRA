using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class GroupUsersController : Controller
    {
        private readonly PrafichteContext _context;

        public GroupUsersController(PrafichteContext context)
        {
            _context = context;
        }

        // GET: GroupUsers
        public async Task<IActionResult> Index()
        {
            var prafichteContext = _context.GroupUsers.Include(g => g.Group).Include(g => g.User);
            return View(await prafichteContext.ToListAsync());
        }

        // GET: GroupUsers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupUser = await _context.GroupUsers
                .Include(g => g.Group)
                .Include(g => g.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (groupUser == null)
            {
                return NotFound();
            }

            return View(groupUser);
        }

        // GET: GroupUsers/Create
        public IActionResult Create()
        {
            ViewData["GroupId"] = new SelectList(_context.Groups, "Id", "Id");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: GroupUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,GroupId")] GroupUser groupUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(groupUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GroupId"] = new SelectList(_context.Groups, "Id", "Id", groupUser.GroupId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", groupUser.UserId);
            return View(groupUser);
        }

        // GET: GroupUsers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupUser = await _context.GroupUsers.FindAsync(id);
            if (groupUser == null)
            {
                return NotFound();
            }
            ViewData["GroupId"] = new SelectList(_context.Groups, "Id", "Id", groupUser.GroupId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", groupUser.UserId);
            return View(groupUser);
        }

        // POST: GroupUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,GroupId")] GroupUser groupUser)
        {
            if (id != groupUser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(groupUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GroupUserExists(groupUser.Id))
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
            ViewData["GroupId"] = new SelectList(_context.Groups, "Id", "Id", groupUser.GroupId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", groupUser.UserId);
            return View(groupUser);
        }

        // GET: GroupUsers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupUser = await _context.GroupUsers
                .Include(g => g.Group)
                .Include(g => g.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (groupUser == null)
            {
                return NotFound();
            }

            return View(groupUser);
        }

        // POST: GroupUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var groupUser = await _context.GroupUsers.FindAsync(id);
            if (groupUser != null)
            {
                _context.GroupUsers.Remove(groupUser);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GroupUserExists(int id)
        {
            return _context.GroupUsers.Any(e => e.Id == id);
        }
    }
}

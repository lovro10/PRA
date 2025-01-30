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
    public class FriendsController : Controller
    {
        private readonly PrafichteContext _context;

        public FriendsController(PrafichteContext context)
        {
            _context = context;
        }

        // GET: Friends
        public async Task<IActionResult> Index()
        {
            var prafichteContext = _context.Friends.Include(f => f.Reciever).Include(f => f.Sender);
            return View(await prafichteContext.ToListAsync());
        }

        // GET: Friends/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var friend = await _context.Friends
                .Include(f => f.Reciever)
                .Include(f => f.Sender)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (friend == null)
            {
                return NotFound();
            }

            return View(friend);
        }

        // GET: Friends/Create
        public IActionResult Create()
        {
            ViewData["RecieverId"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["SenderId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Friends/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SenderId,RecieverId,DateSent,IsAccepted")] Friend friend)
        {
            if (ModelState.IsValid)
            {
                _context.Add(friend);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RecieverId"] = new SelectList(_context.Users, "Id", "Id", friend.RecieverId);
            ViewData["SenderId"] = new SelectList(_context.Users, "Id", "Id", friend.SenderId);
            return View(friend);
        }

        // GET: Friends/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var friend = await _context.Friends.FindAsync(id);
            if (friend == null)
            {
                return NotFound();
            }
            ViewData["RecieverId"] = new SelectList(_context.Users, "Id", "Id", friend.RecieverId);
            ViewData["SenderId"] = new SelectList(_context.Users, "Id", "Id", friend.SenderId);
            return View(friend);
        }

        // POST: Friends/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SenderId,RecieverId,DateSent,IsAccepted")] Friend friend)
        {
            if (id != friend.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(friend);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FriendExists(friend.Id))
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
            ViewData["RecieverId"] = new SelectList(_context.Users, "Id", "Id", friend.RecieverId);
            ViewData["SenderId"] = new SelectList(_context.Users, "Id", "Id", friend.SenderId);
            return View(friend);
        }

        // GET: Friends/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var friend = await _context.Friends
                .Include(f => f.Reciever)
                .Include(f => f.Sender)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (friend == null)
            {
                return NotFound();
            }

            return View(friend);
        }

        // POST: Friends/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var friend = await _context.Friends.FindAsync(id);
            if (friend != null)
            {
                _context.Friends.Remove(friend);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FriendExists(int id)
        {
            return _context.Friends.Any(e => e.Id == id);
        }
    }
}

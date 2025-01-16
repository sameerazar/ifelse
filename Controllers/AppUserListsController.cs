using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CustomIdentity.Data;
using CustomIdentity.Models;

namespace CustomIdentity.Controllers
{
    public class AppUserListsController : Controller
    {
        private readonly AppDbContext _context;

        public AppUserListsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: AppUserLists
        public async Task<IActionResult> Index()
        {
         
                    
            return View(await _context.AppUserLists.ToListAsync());
        }

        // GET: AppUserLists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appUserList = await _context.AppUserLists
                .FirstOrDefaultAsync(m => m.id == id);
            if (appUserList == null)
            {
                return NotFound();
            }

            return View(appUserList);
        }

        // GET: AppUserLists/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AppUserLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Name,Mobile,Email,Address")] AppUserList appUserList)
        {
            if (ModelState.IsValid)
            {
                _context.Add(appUserList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(appUserList);
        }

        // GET: AppUserLists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            bool canEdit = true; // Example condition

            ViewBag.IsEditable = canEdit;
            if (id == null)
            {
                return NotFound();
            }

            var appUserList = await _context.AppUserLists.FindAsync(id);
            if (appUserList == null)
            {
                return NotFound();
            }
            return View(appUserList);
        }

        // POST: AppUserLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Name,Mobile,Email,Address")] AppUserList appUserList)
        {
            if (id != appUserList.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(appUserList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppUserListExists(appUserList.id))
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
            return View(appUserList);
        }

        // GET: AppUserLists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appUserList = await _context.AppUserLists
                .FirstOrDefaultAsync(m => m.id == id);
            if (appUserList == null)
            {
                return NotFound();
            }

            return View(appUserList);
        }

        // POST: AppUserLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var appUserList = await _context.AppUserLists.FindAsync(id);
            if (appUserList != null)
            {
                _context.AppUserLists.Remove(appUserList);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AppUserListExists(int id)
        {
            return _context.AppUserLists.Any(e => e.id == id);
        }
    }
}

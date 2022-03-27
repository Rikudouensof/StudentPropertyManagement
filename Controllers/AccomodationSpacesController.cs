using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentPropertyManagement.Data;
using StudentPropertyManagement.Models;

namespace StudentPropertyManagement.Controllers
{
  [Authorize(Roles = "Admin")]
  public class AccomodationSpacesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccomodationSpacesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AccomodationSpaces
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.AccomodationSpaces.Include(a => a.Gender);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: AccomodationSpaces/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accomodationSpace = await _context.AccomodationSpaces
                .Include(a => a.Gender)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (accomodationSpace == null)
            {
                return NotFound();
            }

            return View(accomodationSpace);
        }

        // GET: AccomodationSpaces/Create
        public IActionResult Create()
        {
            ViewData["GenderId"] = new SelectList(_context.Genders, "Id", "Name");
            return View();
        }

        // POST: AccomodationSpaces/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Capacity,GenderId")] AccomodationSpace accomodationSpace)
        {
            if (ModelState.IsValid)
            {
                _context.Add(accomodationSpace);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GenderId"] = new SelectList(_context.Genders, "Id", "Name", accomodationSpace.GenderId);
            return View(accomodationSpace);
        }

        // GET: AccomodationSpaces/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accomodationSpace = await _context.AccomodationSpaces.FindAsync(id);
            if (accomodationSpace == null)
            {
                return NotFound();
            }
            ViewData["GenderId"] = new SelectList(_context.Genders, "Id", "Name", accomodationSpace.GenderId);
            return View(accomodationSpace);
        }

        // POST: AccomodationSpaces/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Capacity,GenderId")] AccomodationSpace accomodationSpace)
        {
            if (id != accomodationSpace.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(accomodationSpace);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccomodationSpaceExists(accomodationSpace.Id))
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
            ViewData["GenderId"] = new SelectList(_context.Genders, "Id", "Name", accomodationSpace.GenderId);
            return View(accomodationSpace);
        }

        // GET: AccomodationSpaces/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accomodationSpace = await _context.AccomodationSpaces
                .Include(a => a.Gender)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (accomodationSpace == null)
            {
                return NotFound();
            }

            return View(accomodationSpace);
        }

        // POST: AccomodationSpaces/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var accomodationSpace = await _context.AccomodationSpaces.FindAsync(id);
            _context.AccomodationSpaces.Remove(accomodationSpace);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AccomodationSpaceExists(int id)
        {
            return _context.AccomodationSpaces.Any(e => e.Id == id);
        }
    }
}

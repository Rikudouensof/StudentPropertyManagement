using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentPropertyManagement.Data;
using StudentPropertyManagement.Models;

namespace StudentPropertyManagement.Controllers
{
    public class AccomodationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccomodationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Accomodations
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Accomodations.Include(a => a.Space).Include(a => a.Student);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Accomodations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accomodation = await _context.Accomodations
                .Include(a => a.Space)
                .Include(a => a.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (accomodation == null)
            {
                return NotFound();
            }

            return View(accomodation);
        }

        // GET: Accomodations/Create
        public IActionResult Create()
        {
            ViewData["SpaceId"] = new SelectList(_context.AccomodationSpaces, "Id", "Id");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Accomodations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,ExpiryDate,JoinedDate,AccomodationPosition,UserId,SpaceId")] Accomodation accomodation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(accomodation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SpaceId"] = new SelectList(_context.AccomodationSpaces, "Id", "Id", accomodation.SpaceId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", accomodation.UserId);
            return View(accomodation);
        }

        // GET: Accomodations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accomodation = await _context.Accomodations.FindAsync(id);
            if (accomodation == null)
            {
                return NotFound();
            }
            ViewData["SpaceId"] = new SelectList(_context.AccomodationSpaces, "Id", "Id", accomodation.SpaceId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", accomodation.UserId);
            return View(accomodation);
        }

        // POST: Accomodations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ExpiryDate,JoinedDate,AccomodationPosition,UserId,SpaceId")] Accomodation accomodation)
        {
            if (id != accomodation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(accomodation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccomodationExists(accomodation.Id))
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
            ViewData["SpaceId"] = new SelectList(_context.AccomodationSpaces, "Id", "Id", accomodation.SpaceId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", accomodation.UserId);
            return View(accomodation);
        }

        // GET: Accomodations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accomodation = await _context.Accomodations
                .Include(a => a.Space)
                .Include(a => a.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (accomodation == null)
            {
                return NotFound();
            }

            return View(accomodation);
        }

        // POST: Accomodations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var accomodation = await _context.Accomodations.FindAsync(id);
            _context.Accomodations.Remove(accomodation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AccomodationExists(int id)
        {
            return _context.Accomodations.Any(e => e.Id == id);
        }
    }
}

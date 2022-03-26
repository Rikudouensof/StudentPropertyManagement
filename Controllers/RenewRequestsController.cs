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
    public class RenewRequestsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RenewRequestsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RenewRequests
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.RenewRequests.Include(r => r.Student);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: RenewRequests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var renewRequest = await _context.RenewRequests
                .Include(r => r.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (renewRequest == null)
            {
                return NotFound();
            }

            return View(renewRequest);
        }

        // GET: RenewRequests/Create
        public IActionResult Create()
        {
            ViewData["StudentId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: RenewRequests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StudentId,DateRequested,isFulfiled")] RenewRequest renewRequest)
        {
            if (ModelState.IsValid)
            {
                _context.Add(renewRequest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StudentId"] = new SelectList(_context.Users, "Id", "Id", renewRequest.StudentId);
            return View(renewRequest);
        }

        // GET: RenewRequests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var renewRequest = await _context.RenewRequests.FindAsync(id);
            if (renewRequest == null)
            {
                return NotFound();
            }
            ViewData["StudentId"] = new SelectList(_context.Users, "Id", "Id", renewRequest.StudentId);
            return View(renewRequest);
        }

        // POST: RenewRequests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StudentId,DateRequested,isFulfiled")] RenewRequest renewRequest)
        {
            if (id != renewRequest.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(renewRequest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RenewRequestExists(renewRequest.Id))
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
            ViewData["StudentId"] = new SelectList(_context.Users, "Id", "Id", renewRequest.StudentId);
            return View(renewRequest);
        }

        // GET: RenewRequests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var renewRequest = await _context.RenewRequests
                .Include(r => r.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (renewRequest == null)
            {
                return NotFound();
            }

            return View(renewRequest);
        }

        // POST: RenewRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var renewRequest = await _context.RenewRequests.FindAsync(id);
            _context.RenewRequests.Remove(renewRequest);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RenewRequestExists(int id)
        {
            return _context.RenewRequests.Any(e => e.Id == id);
        }
    }
}

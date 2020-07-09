using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HolidayManagement.Models;

namespace HolidayManagement.Controllers
{
    public class StaffsController : Controller
    {
        private readonly Context _context;

        public StaffsController(Context context)
        {
            _context = context;
        }

        // GET: Staffs
        public async Task<IActionResult> Index()
        {
            var context = _context.MyStaff.Include(s => s.Office).Include(s => s.StaffStatus);
            return View(await context.ToListAsync());
        }
        public async Task<IActionResult> Index2()
        {
            var context = _context.MyStaff.Include(s => s.Office).Include(s => s.StaffStatus);
            return View(await context.ToListAsync());
        }

        // GET: Staffs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staff = await _context.MyStaff
                .Include(s => s.Office)
                .Include(s => s.StaffStatus)
                .FirstOrDefaultAsync(m => m.StaffID == id);
            if (staff == null)
            {
                return NotFound();
            }

            return View(staff);
        }

        // GET: Staffs/Create
        public IActionResult Create()
        {
            ViewData["OfficeID"] = new SelectList(_context.MyOffices, "OfficeID", "OfficeID");
            ViewData["StaffStatusID"] = new SelectList(_context.MyStaffStatuses, "StaffStatusID", "StaffStatusID");
            return View();
        }

        // POST: Staffs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StaffID,FirstName,LastName,OfficeID,StaffStatusID")] Staff staff)
        {
            if (ModelState.IsValid)
            {
                _context.Add(staff);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OfficeID"] = new SelectList(_context.MyOffices, "OfficeID", "OfficeID", staff.OfficeID);
            ViewData["StaffStatusID"] = new SelectList(_context.MyStaffStatuses, "StaffStatusID", "StaffStatusID", staff.StaffStatusID);
            return View(staff);
        }

        // GET: Staffs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staff = await _context.MyStaff.FindAsync(id);
            if (staff == null)
            {
                return NotFound();
            }
            ViewData["OfficeID"] = new SelectList(_context.MyOffices, "OfficeID", "OfficeID", staff.OfficeID);
            ViewData["StaffStatusID"] = new SelectList(_context.MyStaffStatuses, "StaffStatusID", "StaffStatusID", staff.StaffStatusID);
            return View(staff);
        }

        // POST: Staffs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StaffID,FirstName,LastName,OfficeID,StaffStatusID")] Staff staff)
        {
            if (id != staff.StaffID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(staff);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StaffExists(staff.StaffID))
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
            ViewData["OfficeID"] = new SelectList(_context.MyOffices, "OfficeID", "OfficeID", staff.OfficeID);
            ViewData["StaffStatusID"] = new SelectList(_context.MyStaffStatuses, "StaffStatusID", "StaffStatusID", staff.StaffStatusID);
            return View(staff);
        }

        // GET: Staffs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staff = await _context.MyStaff
                .Include(s => s.Office)
                .Include(s => s.StaffStatus)
                .FirstOrDefaultAsync(m => m.StaffID == id);
            if (staff == null)
            {
                return NotFound();
            }

            return View(staff);
        }

        // POST: Staffs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var staff = await _context.MyStaff.FindAsync(id);
            _context.MyStaff.Remove(staff);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StaffExists(int id)
        {
            return _context.MyStaff.Any(e => e.StaffID == id);
        }
    }
}

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
    public class HolidayTypesController : Controller
    {
        private readonly Context _context;

        public HolidayTypesController(Context context)
        {
            _context = context;
        }

        // GET: HolidayTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.MyHolidayTypes.ToListAsync());
        }

        // GET: HolidayTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var holidayType = await _context.MyHolidayTypes
                .FirstOrDefaultAsync(m => m.HolidayTypeID == id);
            if (holidayType == null)
            {
                return NotFound();
            }

            return View(holidayType);
        }

        // GET: HolidayTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HolidayTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HolidayTypeID,Type")] HolidayType holidayType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(holidayType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(holidayType);
        }

        // GET: HolidayTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var holidayType = await _context.MyHolidayTypes.FindAsync(id);
            if (holidayType == null)
            {
                return NotFound();
            }
            return View(holidayType);
        }

        // POST: HolidayTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HolidayTypeID,Type")] HolidayType holidayType)
        {
            if (id != holidayType.HolidayTypeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(holidayType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HolidayTypeExists(holidayType.HolidayTypeID))
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
            return View(holidayType);
        }

        // GET: HolidayTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var holidayType = await _context.MyHolidayTypes
                .FirstOrDefaultAsync(m => m.HolidayTypeID == id);
            if (holidayType == null)
            {
                return NotFound();
            }

            return View(holidayType);
        }

        // POST: HolidayTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var holidayType = await _context.MyHolidayTypes.FindAsync(id);
            _context.MyHolidayTypes.Remove(holidayType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HolidayTypeExists(int id)
        {
            return _context.MyHolidayTypes.Any(e => e.HolidayTypeID == id);
        }
    }
}

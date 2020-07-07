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
    public class RequestsController : Controller
    {
        private readonly Context _context;

        public RequestsController(Context context)
        {
            _context = context;
        }

        // GET: Requests
        public async Task<IActionResult> Index()
        {
            var context = _context.MyRequests.Include(r => r.HolidayType).Include(r => r.RequestStatus).Include(r => r.Staff);
            return View(await context.ToListAsync());
        }

        // GET: Requests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var request = await _context.MyRequests
                .Include(r => r.HolidayType)
                .Include(r => r.RequestStatus)
                .Include(r => r.Staff)
                .FirstOrDefaultAsync(m => m.RequestID == id);
            if (request == null)
            {
                return NotFound();
            }

            return View(request);
        }

        // GET: Requests/Create
        public IActionResult Create()
        {
            ViewData["HolidayTypeID"] = new SelectList(_context.MyHolidayTypes, "HolidayTypeID", "HolidayTypeID");
            ViewData["RequestStatusID"] = new SelectList(_context.MyRequestStatuses, "RequestStatusID", "RequestStatusID");
            ViewData["StaffID"] = new SelectList(_context.MyStaff, "StaffID", "StaffID");
            return View();
        }

        // POST: Requests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RequestID,StaffID,RequestStatusID,StartDate,EndDate,HolidayTypeID")] Request request)
        {
            if (ModelState.IsValid)
            {
                _context.Add(request);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HolidayTypeID"] = new SelectList(_context.MyHolidayTypes, "HolidayTypeID", "HolidayTypeID", request.HolidayTypeID);
            ViewData["RequestStatusID"] = new SelectList(_context.MyRequestStatuses, "RequestStatusID", "RequestStatusID", request.RequestStatusID);
            ViewData["StaffID"] = new SelectList(_context.MyStaff, "StaffID", "StaffID", request.StaffID);
            return View(request);
        }

        // GET: Requests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var request = await _context.MyRequests.FindAsync(id);
            if (request == null)
            {
                return NotFound();
            }
            ViewData["HolidayTypeID"] = new SelectList(_context.MyHolidayTypes, "HolidayTypeID", "HolidayTypeID", request.HolidayTypeID);
            ViewData["RequestStatusID"] = new SelectList(_context.MyRequestStatuses, "RequestStatusID", "RequestStatusID", request.RequestStatusID);
            ViewData["StaffID"] = new SelectList(_context.MyStaff, "StaffID", "StaffID", request.StaffID);
            return View(request);
        }

        // POST: Requests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RequestID,StaffID,RequestStatusID,StartDate,EndDate,HolidayTypeID")] Request request)
        {
            if (id != request.RequestID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(request);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RequestExists(request.RequestID))
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
            ViewData["HolidayTypeID"] = new SelectList(_context.MyHolidayTypes, "HolidayTypeID", "HolidayTypeID", request.HolidayTypeID);
            ViewData["RequestStatusID"] = new SelectList(_context.MyRequestStatuses, "RequestStatusID", "RequestStatusID", request.RequestStatusID);
            ViewData["StaffID"] = new SelectList(_context.MyStaff, "StaffID", "StaffID", request.StaffID);
            return View(request);
        }

        // GET: Requests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var request = await _context.MyRequests
                .Include(r => r.HolidayType)
                .Include(r => r.RequestStatus)
                .Include(r => r.Staff)
                .FirstOrDefaultAsync(m => m.RequestID == id);
            if (request == null)
            {
                return NotFound();
            }

            return View(request);
        }

        public async Task<IActionResult> Reject(int id)
        {
            var request = await _context.MyRequests.FindAsync(id);
            request.RequestStatus = _context.MyRequestStatuses.Find(2);

            try
            {
                _context.Update(request);
                await _context.SaveChangesAsync();
            }catch(DbUpdateConcurrencyException)
            {
                if(RequestExists(request.RequestID))
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

        // POST: Requests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var request = await _context.MyRequests.FindAsync(id);
            _context.MyRequests.Remove(request);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RequestExists(int id)
        {
            return _context.MyRequests.Any(e => e.RequestID == id);
        }
    }
}

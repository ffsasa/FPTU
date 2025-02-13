using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Psychological.Repository.DBContext;
using Psychological.Repository.Models;

namespace Psychological.MVCWebApp.Controllers
{
    public class ServeyCategoriesController : Controller
    {
        private readonly NET1720_PRN231_PRJ_G1_SchoolPsychologicalHealthSupportSystemContext _context;

        public ServeyCategoriesController(NET1720_PRN231_PRJ_G1_SchoolPsychologicalHealthSupportSystemContext context)
        {
            _context = context;
        }

        // GET: ServeyCategories
        public async Task<IActionResult> Index()
        {
            return View(await _context.ServeyCategories.ToListAsync());
        }

        // GET: ServeyCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serveyCategory = await _context.ServeyCategories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (serveyCategory == null)
            {
                return NotFound();
            }

            return View(serveyCategory);
        }

        // GET: ServeyCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ServeyCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,CreateAt,UpdateAt")] ServeyCategory serveyCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(serveyCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(serveyCategory);
        }

        // GET: ServeyCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serveyCategory = await _context.ServeyCategories.FindAsync(id);
            if (serveyCategory == null)
            {
                return NotFound();
            }
            return View(serveyCategory);
        }

        // POST: ServeyCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,CreateAt,UpdateAt")] ServeyCategory serveyCategory)
        {
            if (id != serveyCategory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(serveyCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServeyCategoryExists(serveyCategory.Id))
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
            return View(serveyCategory);
        }

        // GET: ServeyCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serveyCategory = await _context.ServeyCategories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (serveyCategory == null)
            {
                return NotFound();
            }

            return View(serveyCategory);
        }

        // POST: ServeyCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var serveyCategory = await _context.ServeyCategories.FindAsync(id);
            if (serveyCategory != null)
            {
                _context.ServeyCategories.Remove(serveyCategory);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServeyCategoryExists(int id)
        {
            return _context.ServeyCategories.Any(e => e.Id == id);
        }
    }
}

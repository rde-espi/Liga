using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Liga.web.Data;
using Liga.web.Models.Entity;
using Microsoft.AspNetCore.Authorization;

namespace Liga.web.Controllers
{
    [Authorize]
    public class PlayerEntitiesController : Controller
    {
        private readonly DataContext _context;

        public PlayerEntitiesController(DataContext context)
        {
            _context = context;
        }

        // GET: PlayerEntities
        public async Task<IActionResult> Index()
        {
            return View(await _context.Players.ToListAsync());
        }

        // GET: PlayerEntities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playerEntity = await _context.Players
                .FirstOrDefaultAsync(m => m.Id == id);
            if (playerEntity == null)
            {
                return NotFound();
            }

            return View(playerEntity);
        }

        // GET: PlayerEntities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PlayerEntities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Salary,IsActive")] PlayerEntity playerEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(playerEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(playerEntity);
        }

        // GET: PlayerEntities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playerEntity = await _context.Players.FindAsync(id);
            if (playerEntity == null)
            {
                return NotFound();
            }
            return View(playerEntity);
        }

        // POST: PlayerEntities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Salary,IsActive")] PlayerEntity playerEntity)
        {
            if (id != playerEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(playerEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlayerEntityExists(playerEntity.Id))
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
            return View(playerEntity);
        }

        // GET: PlayerEntities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playerEntity = await _context.Players
                .FirstOrDefaultAsync(m => m.Id == id);
            if (playerEntity == null)
            {
                return NotFound();
            }

            return View(playerEntity);
        }

        // POST: PlayerEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var playerEntity = await _context.Players.FindAsync(id);
            _context.Players.Remove(playerEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlayerEntityExists(int id)
        {
            return _context.Players.Any(e => e.Id == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Liga.web.Data;
using Liga.web.Models.Entity;

namespace Liga.web.Controllers
{
    public class TeamsController : Controller
    {
        private readonly ITeamRepository _teamRepository;

        public TeamsController(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        // GET: Teams
        public async Task<IActionResult> Index()
        {
            return View(_teamRepository.GetAll());
        }

        // GET: Teams/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teamEntity = await _teamRepository.GetByIdAsync(id.Value);
            if (teamEntity == null)
            {
                return NotFound();
            }

            return View(teamEntity);
        }

        // GET: Teams/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Teams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TeamEntity teamEntity)
        {
            if (ModelState.IsValid)
            {
                await _teamRepository.CreateAsync(teamEntity);
                return RedirectToAction(nameof(Index));
            }
            return View(teamEntity);
        }

        // GET: Teams/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teamEntity = await _teamRepository.GetByIdAsync(id.Value);
            if (teamEntity == null)
            {
                return NotFound();
            }
            return View(teamEntity);
        }

        // POST: Teams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,TeamEntity teamEntity)
        {
            if (id != teamEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _teamRepository.UpdateAsync(teamEntity);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _teamRepository.ExistAsync(teamEntity.Id))
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
            return View(teamEntity);
        }

        // GET: Teams/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teamEntity = await _teamRepository.GetByIdAsync(id.Value);
            if (teamEntity == null)
            {
                return NotFound();
            }

            return View(teamEntity);
        }

        // POST: Teams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var teamEntity = await _teamRepository.GetByIdAsync(id);
            await _teamRepository.DeleteAsync(teamEntity);
            return RedirectToAction(nameof(Index));
        }
    }
}

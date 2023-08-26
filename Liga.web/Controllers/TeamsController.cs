using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Liga.web.Data;
using Liga.web.Models.Entity;
using Liga.web.Helpers;
using Liga.web.Models;
using System.IO;
using Microsoft.VisualBasic;

namespace Liga.web.Controllers
{
    public class TeamsController : Controller
    {
        private readonly ITeamRepository _teamRepository;
        private readonly IUserHelper _userHelper;

        public TeamsController(
            ITeamRepository teamRepository,
            IUserHelper userHelper)
        {
            _teamRepository = teamRepository;
            _userHelper = userHelper;
        }

        // GET: Teams
        public async Task<IActionResult> Index()
        {
            return View(_teamRepository.GetAll().OrderBy(t=>t.Name));
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
        public async Task<IActionResult> Create(TeamViewModel model)
        {
            if (ModelState.IsValid)
            {
                var path = string.Empty;
                if(model.Imagefile != null && model.Imagefile.Length > 0)
                {
                    var guid = Guid.NewGuid().ToString();
                    var file = $"{guid}.jpg";

                    path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\Teams",file);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await model.Imagefile.CopyToAsync(stream);
                    }
                    path = $"~/images/Teams/{file}";
                }

                var teamEntity = this.ToTeam(model, path);
                teamEntity.User = await _userHelper.GetUserByEmailAsync("reinaldo_7531@hotmail.com");
                await _teamRepository.CreateAsync(teamEntity);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        private TeamEntity ToTeam(TeamViewModel model, string path)
        {
            return new TeamEntity
            {
                Id = model.Id,
                Name = model.Name,
                PathLogo = path,
                User = model.User
            };
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
            var model = ToTeamViewModel(teamEntity);
            return View(model);
        }

        private object ToTeamViewModel(TeamEntity teamEntity)
        {
            return new TeamViewModel
            {
                Id = teamEntity.Id,
                Name = teamEntity.Name,
                PathLogo = teamEntity.PathLogo,
                User = teamEntity.User
            };
        }

        // POST: Teams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TeamViewModel model)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var path = model.PathLogo;
                    if(model.Imagefile != null && model.Imagefile.Length > 0)
                    {
                        var guid = Guid.NewGuid().ToString();
                        var file = $"{guid}.jpg";
                        path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\Teams", file);
                        using(var stream = new FileStream(path, FileMode.Create))
                        {
                            await model.Imagefile.CopyToAsync(stream);
                        }
                        path = $"~/images/Teams/{file}";
                    }

                    var teamEntity = this.ToTeam(model, path);
                    teamEntity.User = await _userHelper.GetUserByEmailAsync("reinaldo_7531@hotmail.com");
                    await _teamRepository.UpdateAsync(teamEntity);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _teamRepository.ExistAsync(model.Id))
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
            return View(model);
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

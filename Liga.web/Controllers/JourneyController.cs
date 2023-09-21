﻿using Liga.web.Data;
using Liga.web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Liga.web.Controllers
{
    [Authorize]
    public class JourneyController : Controller
    {
        private readonly IJourneyRepository _journeyRepository;
        private readonly ITeamRepository _teamRepository;

        public JourneyController(IJourneyRepository journeyRepository, ITeamRepository teamRepository)
        {
            _journeyRepository = journeyRepository;
            _teamRepository = teamRepository;
        }
        public async Task<IActionResult> Index()
        {
            var model = await _journeyRepository.GetJourneyAsync(this.User.Identity.Name);
            return View(model);
        }
        public async Task<IActionResult> Create()
        {
            var model = await _journeyRepository.GetJourneyDetailTempAsync(this.User.Identity.Name);
            return View(model);
        }

        public IActionResult AddGame()
        {
            var model = new AddItemsViewModel
            {
                Teams = _teamRepository.GetComboTeams(),
            };
            return View(model);
        }
       
    }
}

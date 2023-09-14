using Liga.web.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Liga.web.Controllers
{
    [Authorize]
    public class JourneyController : Controller
    {
        private readonly IJourneyRepository _journeyRepository;

        public JourneyController(IJourneyRepository journeyRepository)
        {
            _journeyRepository = journeyRepository;
        }
        public async Task<IActionResult> Index()
        {
            var model = await _journeyRepository.GetJourneyAsync(this.User.Identity.Name);
            return View(model);
        }
    }
}

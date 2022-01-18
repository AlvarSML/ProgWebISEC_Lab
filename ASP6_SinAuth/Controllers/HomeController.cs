using ASP6_SinAuth.Areas.Identity.Data;
using ASP6_SinAuth.Data;
using ASP6_SinAuth.Models;
using ASP6_SinAuth.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace ASP6_SinAuth.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<User> _userManager;
        private readonly ctxDatos _context;

        public HomeController(ILogger<HomeController> logger,ctxDatos context, UserManager<User> uMng)
        {
            _logger = logger;
            _context = context;
            _userManager = uMng;
        }

        // /GET/INDEX
        public async Task<IActionResult> Index()
        {
            ClientHome ch = new ClientHome();
            string userId = _userManager.GetUserId(User);

            Boolean a = User.IsInRole("LaboratoryWorker");

            IEnumerable<Test> testsUser = await _context.Test
                .Include(t => t.client)
                .Where(t => t.client.Id == userId)
                .Include(t => t.type)
                .Include(t => t.technician)
                .Include(t => t.laboratory)
                .ToListAsync();

            ch.FutureTests = testsUser
                .Where(t => t.testDate.CompareTo(DateTime.Now) > 0);


            ch.Results = testsUser
                .Where(t => t.result != null);

            return View(ch);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
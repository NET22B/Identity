using Identity.Data;
using Identity.Models;
using Identity.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Identity.Controllers
{
   // [Authorize]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext db;
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<Member> userManager;

        public HomeController(ApplicationDbContext db,ILogger<HomeController> logger, UserManager<Member> userManager)
        {
            this.db = db;
            _logger = logger;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var res = db.Users.Where(v => v.IsPro == true);

            var user = await userManager.GetUserAsync(User);

            if (!User.Identity.IsAuthenticated)
            {

            }
            return View();
        }

        [Authorize]
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
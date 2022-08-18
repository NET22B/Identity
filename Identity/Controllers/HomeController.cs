using Identity.Data;
using Identity.Models;
using Identity.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Identity.Controllers
{
   [Authorize(Roles ="Admin")]
    public class HomeController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly ApplicationDbContext db;
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<Member> userManager;

        public HomeController(RoleManager<IdentityRole> roleManager, ApplicationDbContext db,ILogger<HomeController> logger, UserManager<Member> userManager)
        {
            this.roleManager = roleManager;
            this.db = db;
            _logger = logger;
            this.userManager = userManager;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var res = db.Users.Where(v => v.IsPro == true).ToList();

            foreach (var item in res)
            {
               var r = userManager.AddToRoleAsync(item, "Admin");
            }

            var user = await userManager.GetUserAsync(User);

            userManager.AddToRoleAsync(user, "Admin");

            var res2 = await roleManager.CreateAsync(new IdentityRole { Name = "Admin" });

            if (!res2.Succeeded)
            {
                //
            }

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
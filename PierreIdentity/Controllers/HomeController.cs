
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using PierreIdentity.Models;
using PierreIdentity.ViewModels;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;


namespace PierreIdentity.Controllers
{
    public class HomeController : Controller
    {
        private readonly PierreIdentityContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(UserManager<ApplicationUser> userManager, PierreIdentityContext db)
        {
        _userManager = userManager;
        _db = db;
        }

        public ActionResult Index()
        {
            var viewModel = new ListAllViewModel 
            { 
                Treats = _db.Treats.ToList(),
                Flavors = _db.Flavors.ToList()
            };
            return View(viewModel);
        }
    }
}
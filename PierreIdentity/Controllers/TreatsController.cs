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
  [Authorize]
  public class TreatsController : Controller
  {
    private readonly PierreIdentityContext _db;
    private readonly UserManager<ApplicationUser> _userManager;

    public TreatsController(UserManager<ApplicationUser> userManager, PierreIdentityContext db)
    {
      _userManager = userManager;
      _db = db;
    }
    [AllowAnonymous]
    public ActionResult Index ()
    {
      List<Treat> model = _db.Treats.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public async Task<ActionResult> Create(Treat treat)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      treat.User = currentUser;
      _db.Treats.Add(treat);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    [AllowAnonymous]
    public ActionResult Details(int id)
    {
      var thisTreat = _db.Treats
        .Include(treat => treat.TreatFlavors)
        .ThenInclude(join => join.Flavor)
        .FirstOrDefault(treat => treat.TreatId == id);
      return View(thisTreat);
    } 

    public ActionResult Edit(int id)
    {
      var thisTreat = _db.Treats.FirstOrDefault(treat => treat.TreatId == id);
      return View(thisTreat);
    }

    [HttpPost]
    public ActionResult Edit(Treat treat)
    {
      _db.Entry(treat).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisTreat = _db.Treats.FirstOrDefault(treat => treat.TreatId == id);
      return View(thisTreat);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisTreat = _db.Treats.FirstOrDefault(treat => treat.TreatId == id);
      _db.Treats.Remove(thisTreat);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddFlavor(int id)
    {
      var treat = _db.Treats.FirstOrDefault(treat => treat.TreatId == id);
      var viewModel = new AddFlavorViewModel 
      {
        Treat = treat,
        Flavors = _db.Flavors.Select(flavor => new SelectFlavorViewModel 
        { 
          FlavorId = flavor.FlavorId, 
          Name = flavor.Name, 
          IsSelected = _db.TreatFlavors.Where(entry => entry.TreatId == id).Any(entry => entry.FlavorId == flavor.FlavorId)
          }).ToList()
      };
    
      return View(viewModel);
    }

    [HttpPost]
    public ActionResult AddFlavor(AddFlavorViewModel viewModel, int id)
    {
      if (viewModel.Flavors.Any())
      {
        foreach(var selectedFlavor in viewModel.Flavors.Where(flavor => flavor.IsSelected))
        {
          if(!_db.TreatFlavors.Where(entry => entry.TreatId == viewModel.Treat.TreatId).Any(entry => entry.FlavorId == selectedFlavor.FlavorId))
          {
          _db.TreatFlavors.Add(new TreatFlavor() { TreatId = viewModel.Treat.TreatId, FlavorId = selectedFlavor.FlavorId
            });
          }
        }
        foreach(var selectedFlavor in viewModel.Flavors.Where(flavor => !flavor.IsSelected))
        {
          var thisTreatFlavor = _db.TreatFlavors.Where(entry => entry.TreatId == viewModel.Treat.TreatId).FirstOrDefault(entry => entry.FlavorId == selectedFlavor.FlavorId);
          if(_db.TreatFlavors.Where(entry => entry.TreatId == viewModel.Treat.TreatId).Any(entry => entry.FlavorId == selectedFlavor.FlavorId))
          {
          // _db.TreatFlavors.Add(new TreatFlavor() { TreatId = viewModel.Treat.TreatId, FlavorId = selectedFlavor.FlavorId});
          _db.TreatFlavors.Remove(thisTreatFlavor);
          }
        _db.SaveChanges();
        }
      }
      return RedirectToAction("Details", new { id = id });
      
    }
  }


}
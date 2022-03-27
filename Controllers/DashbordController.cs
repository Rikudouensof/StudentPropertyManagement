using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentPropertyManagement.Data;
using StudentPropertyManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace StudentPropertyManagement.Controllers
{
  [Authorize]
  public class DashbordController : Controller
  {


    private ApplicationDbContext _db;
    public DashbordController(ApplicationDbContext db)
    {
      _db = db;
    }


    [Authorize(Roles = "Admin")]
    public IActionResult Index()
    {
      return View();
    }

    public IActionResult Profile()
    {
      var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
      var user = _db.Users.Where(m => m.Id == userId).FirstOrDefault();
      ProfileViewModel profileViewModel = new ProfileViewModel()
      {
        Accomodations = _db.Accomodations.Where(m => m.UserId == userId).Include(m => m.Space).OrderByDescending(m => m.JoinedDate),
        User = user
      };
      return View(profileViewModel);
    }

    [HttpPost]
    public IActionResult Profile(ProfileViewModel profileViewModel)
    {
      var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
      var user = _db.Users.Where(m => m.Id == userId).FirstOrDefault();
      if (profileViewModel.User.RegNumber is not null && !string.IsNullOrEmpty(profileViewModel.User.RegNumber))
      {
        var regNo = profileViewModel.User.RegNumber;
        user.RegNumber = regNo;
        user.UserName = regNo;
        _db.Users.Update(user);
        _db.SaveChanges();
      }

      return RedirectToAction("Profile", "Dashbord");
    }
  }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentPropertyManagement.Constants;
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
    public IActionResult ToggleActivate(string Id)
    {

      
      try
      {
        var user = _db.Users.Where(m => m.Id == Id).FirstOrDefault();
        user.EmailConfirmed = !user.EmailConfirmed;
        _db.Users.Update(user);
        _db.SaveChanges();
      }
      catch 
      {

       
      }
      return RedirectToAction("Students", "Dashbord");
    }

    [Authorize(Roles = "Admin")]
    public IActionResult Index()
    {

      DashbordViewModel dashbordViewModel = new DashbordViewModel()
      {
        Accomodations = _db.Accomodations.Include(a => a.Space).Include(a => a.Student).OrderByDescending(m => m.Id),
        TotalAccomodation = _db.Accomodations.Count(),
        TotalSpaces = _db.AccomodationSpaces.Count(),
        TotalStudents = _db.Users.Count() - 1
    };
      return View(dashbordViewModel);
    }

    [Authorize(Roles = "Admin")]
    public IActionResult Students()
    {
      DataIdentityRole dataIdentityRole = new DataIdentityRole();
      StudentsListViewmodel studentsListViewmodel = new StudentsListViewmodel()
      {
        Users = _db.Users.Where(m => m.UserName != dataIdentityRole.RoleAdminName).Include(m => m.Gender)
      };
      return View(studentsListViewmodel);
    }

    [Authorize(Roles = "Admin")]
    public IActionResult StudentDetail(string Id)
    {
      
      var user = _db.Users.Where(m => m.Id == Id).FirstOrDefault();
      ProfileViewModel profileViewModel = new ProfileViewModel()
      {
        Accomodations = _db.Accomodations.Where(m => m.UserId == Id).Include(m => m.Space).OrderByDescending(m => m.JoinedDate),
        User = user
      };
      return View(profileViewModel);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public IActionResult StudentDetail(ProfileViewModel profileViewModel)
    {
      var texUser = profileViewModel.User;
      var userId = texUser.Id;
      var user = _db.Users.Where(m => m.Id == userId).FirstOrDefault();
      if (profileViewModel.User.RegNumber is not null && !string.IsNullOrEmpty(profileViewModel.User.RegNumber))
      {
        var regNo = profileViewModel.User.RegNumber;
        user.RegNumber = regNo;
        user.UserName = regNo;
        
      }

      if (!string.IsNullOrEmpty(texUser.FirstName))
      {
        user.FirstName = texUser.FirstName;
      }

      if (!string.IsNullOrEmpty(texUser.MiddleName))
      {
        user.MiddleName = texUser.MiddleName;
      }

      if (!string.IsNullOrEmpty(texUser.Surname))
      {
        user.Surname = texUser.Surname;
      }

      _db.Users.Update(user);
      _db.SaveChanges();

      return RedirectToAction("StudentDetail", "Dashbord");
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

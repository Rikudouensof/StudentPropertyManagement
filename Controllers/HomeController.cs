using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StudentPropertyManagement.Data;
using StudentPropertyManagement.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using StudentPropertyManagement.ProjectTasks;
using Microsoft.AspNetCore.Identity;
using StudentPropertyManagement.Constants;

namespace StudentPropertyManagement.Controllers
{
  public class HomeController : Controller
  {
    private readonly ILogger<HomeController> _logger;
    private ApplicationDbContext _db;
    private readonly SignInManager<User> _signInManager;
    private readonly UserManager<User> _userManager;
    private RoleManager<IdentityRole> _roleManager;

    public HomeController(ILogger<HomeController> logger, UserManager<User> userManager,
            SignInManager<User> signInManager,
            RoleManager<IdentityRole> roleMgr, ApplicationDbContext db)
    {
      _logger = logger;
      _userManager = userManager;
      _signInManager = signInManager;
      _db = db;
      _roleManager = roleMgr;
    }

    public async Task<IActionResult> Index()
    {

      AddRoleAndAdmin addRoleAndAdmin = new AddRoleAndAdmin(_userManager, _signInManager, _roleManager, _db);
      addRoleAndAdmin.PrepareTheNeedful();
      if (_db.UserRoles.Count() < 1)
      {
        addRoleAndAdmin.CreateIdentityRoleAdmin();
        if (_db.Users.Count() < 1)
        {
          DataIdentityRole dataIdentityRole = new DataIdentityRole();
          var adminUser = new User()
          {
            UserName = "Admin",
            Email = "Admin@StuProp.com",
            Surname = "Admin",
            SecurityStamp = dataIdentityRole.ConcurencyStamd,
            FirstName = "Admin",
            MiddleName = "Admin",
            EmailConfirmed = true,
            RegNumber = "Admin",
            GenderId = 1

          };
          var result = await _userManager.CreateAsync(adminUser, dataIdentityRole.AdminPasseord);
          if (true)
          {
            string resultkk = "";
            int number = 1;
            foreach (var error in result.Errors)
            {

              resultkk += $"\n {number}: {error.Description}";
            }
            Debug.WriteLine(resultkk);

          }
          Console.ReadKey();

        }
        string userId = _db.Users.Select(m => m.Id).FirstOrDefault();
        int cont = _db.Users.Count();
        addRoleAndAdmin.ConnectAdminRoleToUserAdmin(userId);


      }


      ContactUs contactUs = new ContactUs();
      return View(contactUs);
    }

    [HttpPost]
    public IActionResult Index(ContactUs contactUs)
    {
      contactUs.DateSent = DateTime.Now;
      if (ModelState.IsValid)
      {
        _db.ContactUs.Add(contactUs);
        _db.SaveChanges();
        ContactUs contactUsz = new ContactUs();
        ViewData["Name"] = $"Hello {contactUs.FullName}, your message sent sucessfully. Do you want to send another? fill the form bellow.";
        return View("Index", contactUsz);
      }

      return View(contactUs);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}

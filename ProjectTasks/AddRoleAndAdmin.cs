using Microsoft.AspNetCore.Identity;
using StudentPropertyManagement.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentPropertyManagement.Constants;
using StudentPropertyManagement.Models;
using Microsoft.Extensions.Logging;

namespace StudentPropertyManagement.ProjectTasks
{
  public class AddRoleAndAdmin
  {
    public ApplicationDbContext _db;
    private readonly SignInManager<User> _signInManager;
    private readonly UserManager<User> _userManager;
    private RoleManager<IdentityRole> _roleManager;
    public AddRoleAndAdmin(UserManager<User> userManager,
            SignInManager<User> signInManager,
            RoleManager<IdentityRole> roleMgr,
          ApplicationDbContext db)
    {
      _userManager = userManager;
      _signInManager = signInManager;
      _db = db;
      _roleManager = roleMgr;
    }


    private async void PrepareTheNeedful()
    {
      if (_db.UserRoles.Count() < 1)
      {
        CreateIdentityRoleAdmin();
        var userId = await CreateUserAdmin();
        ConnectAdminRoleToUserAdmin(userId);

        List<Gender> coreGender = new List<Gender>();
        coreGender.Add(new Gender { Id = 1, Name = "Not Assigned" });
        coreGender.Add(new Gender { Id = 2, Name = "Male" });
        coreGender.Add(new Gender { Id = 3, Name = "Female" });

        foreach (var item in coreGender)
        {
          _db.Genders.Add(item);
        }
        _db.SaveChanges();
      }
     
    }

    private async  void CreateIdentityRoleAdmin()
    {
      if (_db.Roles.Count() < 1)
      {
        DataIdentityRole dataIdentityRole = new DataIdentityRole();
        IdentityRole adminRole = new IdentityRole
        {
          ConcurrencyStamp = dataIdentityRole.ConcurencyStamd,
          Id = dataIdentityRole.AdminId,
          Name = dataIdentityRole.RoleAdminName,
          NormalizedName = dataIdentityRole.RoleAdminNameAllCaps
        };
        await _roleManager.CreateAsync(adminRole);
        //_db.UserRoles.Add(adminRole);
        //_db.SaveChanges();
      }

    }

    private async Task<string> CreateUserAdmin()
    {
      if (_db.Users.Count() < 1)
      {
        DataIdentityRole dataIdentityRole = new DataIdentityRole();
        User adminUser = new User()
        {
          Email = "Admin@StuProp.com",
          Surname = "Admin",
          SecurityStamp = dataIdentityRole.ConcurencyStamd,
          FirstName = "Admin",
          MiddleName = "Admin",
          EmailConfirmed = true

        };
        var result = await _userManager.CreateAsync(adminUser, dataIdentityRole.AdminPasseord);
        
      }

      var userId = _db.Users.Select(m => m.Id).FirstOrDefault();
      return userId;
    }

    private  void ConnectAdminRoleToUserAdmin(string userId)
    {
      if (_db.UserRoles.Count() < 1)
      {
        DataIdentityRole dataIdentityRole = new DataIdentityRole();
        IdentityUserRole<string> identityUserRole = new IdentityUserRole<string>
        {
          RoleId = dataIdentityRole.AdminId,
          UserId = userId
        };
        _db.UserRoles.Add(identityUserRole);
        _db.SaveChanges();
      }
     
    }


  }
}

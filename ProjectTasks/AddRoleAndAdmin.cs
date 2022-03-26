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
    private  SignInManager<User> _signInManager;
    private  UserManager<User> _userManager;
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


    public async void PrepareTheNeedful()
    {

      if (_db.Genders.Count() < 1)
      {

        List<Gender> coreGender = new List<Gender>();
        coreGender.Add(new Gender {  Name = "Not Assigned" });
        coreGender.Add(new Gender {  Name = "Male" });
        coreGender.Add(new Gender { Name = "Female" });

        foreach (var item in coreGender)
        {
          _db.Genders.Add(item);
        }
        _db.SaveChanges();
      }


      
     
    }

    public async  void CreateIdentityRoleAdmin()
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

    public async void CreateUserAdmin()
    {
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
        if(true)
        {
          string resultkk = "";
          int number = 1;
          foreach (var error in result.Errors)
          {

            resultkk += $"\n {number}: {error.Description}"; 
          }
          System.Diagnostics.Debug.WriteLine(resultkk);

        }
        Console.ReadKey();
        
      }

   
    }

    public  void ConnectAdminRoleToUserAdmin(string userId)
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

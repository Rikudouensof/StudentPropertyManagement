using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentPropertyManagement.Models
{
  public class User : IdentityUser
  {

    public string Surname { get; set; }

    public string FirstName { get; set; }

    public string MiddleName { get; set; }


    public string RegNumber { get; set; }

    public Gender Gender { get; set; }

    public int GenderId { get; set; }

    public DateTime ActiveExpiryDate { get; set; }

    public DateTime ActiveStartTime { get; set; }
  }
}

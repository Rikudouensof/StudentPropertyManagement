using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentPropertyManagement.Models
{
  public class User : IdentityUser
  {

    public string Surname { get; set; }

    [Display(Name = "First Name")]
    public string FirstName { get; set; }


    [Display(Name = "Middle Name")]
    public string MiddleName { get; set; }

    [Display(Name = "Registration Number")]
    public string RegNumber { get; set; }

    public Gender Gender { get; set; }

    [Display(Name = "Gender of Student")]
    public int GenderId { get; set; }

    [Display(Name = " Active Expiry Date")]
    public DateTime ActiveExpiryDate { get; set; }

    [Display(Name = "Active Start Date")]
    public DateTime ActiveStartTime { get; set; }
  }
}

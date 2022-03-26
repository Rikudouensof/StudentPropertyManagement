using StudentPropertyManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentPropertyManagement.ViewModel
{
  public class ProfileViewModel
  {
    [Display(Name = "Active Student")]
    public User User  { get; set; }

    public IEnumerable<Accomodation> Accomodations { get; set; }
  }
}

using StudentPropertyManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentPropertyManagement.ViewModel
{
  public class ProfileViewModel
  {
    public User User  { get; set; }

    public IEnumerable<Accomodation> Accomodations { get; set; }
  }
}

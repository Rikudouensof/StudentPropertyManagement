using StudentPropertyManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentPropertyManagement.ViewModel
{
  public class DashbordViewModel
  {
    public IEnumerable<Accomodation> Accomodations { get; set; }

    public int TotalAccomodation { get; set; }

    public int TotalStudents { get; set; }

    public int TotalSpaces { get; set; }
  }
}

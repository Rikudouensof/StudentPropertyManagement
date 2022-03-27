using StudentPropertyManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentPropertyManagement.ViewModel
{
  public class SpaceDetailsViewmodel
  {

    public AccomodationSpace Space { get; set; }

    public IEnumerable<Accomodation> Accomodations { get; set; }
  }
}

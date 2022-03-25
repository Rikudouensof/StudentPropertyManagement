using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentPropertyManagement.Models
{
  public class AccomodationSpace
  {
    public int Id { get; set; }

    public string Name { get; set; }

    public int Capacity { get; set; }

    public Gender Gender { get; set; }

    public int GenderId { get; set; }
  }
}

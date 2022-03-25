using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentPropertyManagement.Models
{
  public class Accomodation
  {
    public int Id { get; set; }

    public string Name { get; set; }

    public DateTime ExpiryDate { get; set; }

    public DateTime JoinedDate { get; set; }

    public int AccomodationPosition { get; set; }

    public User Student { get; set; }
    public string UserId { get; set; }

    public AccomodationSpace Space { get; set; }

    public int SpaceId { get; set; }
  }
}

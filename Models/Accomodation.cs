using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentPropertyManagement.Models
{
  public class Accomodation
  {
    [Key]
    public int Id { get; set; }

    [Display(Name ="Accomodation Name")]
    public string Name { get; set; }

    [Display(Name = "Elapse Date")]
    public DateTime ExpiryDate { get; set; }

    [Display(Name = "Join Date")]
    public DateTime JoinedDate { get; set; }

    [Display(Name = "Position in Accomodation")]
    public int AccomodationPosition { get; set; }

    public User Student { get; set; }

    [Display(Name = "Student")]
    public string UserId { get; set; }

    public AccomodationSpace Space { get; set; }

    [Display(Name = "Accomodation Space")]
    public int SpaceId { get; set; }
  }
}

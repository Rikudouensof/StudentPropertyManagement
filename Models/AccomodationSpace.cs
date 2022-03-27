using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentPropertyManagement.Models
{
  public class AccomodationSpace
  {
    public int Id { get; set; }


    [Display(Name = "Space Name")]
    public string Name { get; set; }

    [Display(Name = "Student Capacity Number")]
    public int Capacity { get; set; }

    public Gender Gender { get; set; }

    [Display(Name = "Gender Expected to live here")]
    public int GenderId { get; set; }

   
  }
}

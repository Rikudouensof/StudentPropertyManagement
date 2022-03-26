using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentPropertyManagement.Models
{
  public class Buildings
  {
    public int Id { get; set; }


    [Display(Name = "Building Name")]
    public string Name { get; set; }


    public Gender Gender { get; set; }


    [Display(Name = "Gender Expected to Live Here")]
    public int GenderId { get; set; }
  }
}

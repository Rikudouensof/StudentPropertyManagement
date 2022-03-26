using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentPropertyManagement.Models
{
  public class Gender
  {

    public int Id { get; set; }

    [Display(Name = "Gender Name")]
    public string Name { get; set; }
  }
}

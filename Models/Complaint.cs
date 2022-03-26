using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentPropertyManagement.Models
{
  public class Complaint
  {
    public int Id { get; set; }

    public User User { get; set; }

    [Display(Name = "Report From")]
    public string UserId { get; set; }


    public string Message { get; set; }


    [Display(Name = "Date Posted")]
    public DateTime DatePosted { get; set; }
  }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentPropertyManagement.Models
{
  public class RenewRequest
  {
    public int Id { get; set; }

    public User Student { get; set; }


    [Display(Name = "Requesting Student")]
    public string StudentId { get; set; }


    [Display(Name = "Date Requested for Renewal")]
    public DateTime DateRequested { get; set; }


    [Display(Name = "Is Renewal Accepted")]
    public bool isFulfiled { get; set; }
  }
}

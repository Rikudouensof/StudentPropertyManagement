using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentPropertyManagement.Models
{
  public class ContactUs
  {
    [Key]
    public int Id { get; set; }


    [Required]
    [Display(Name = "Full Name")]
    public string FullName { get; set; }

    [Required]
    [EmailAddress]
    [Display(Name = "Email Address")]
    public string Email { get; set; }

    [Display(Name = "Phone Number")]
    public string PhoneNumber { get; set; }

    [Required]
    [Display(Name = "Message")]
    public string Message { get; set; }

    [Display(Name = "Date Sent")]
    public DateTime DateSent { get; set; }

  }
}

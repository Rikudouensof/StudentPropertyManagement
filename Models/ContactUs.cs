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
    public string FullName { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }


    public string PhoneNumber { get; set; }

    [Required]
    public string Message { get; set; }

    public DateTime DateSent { get; set; }

  }
}

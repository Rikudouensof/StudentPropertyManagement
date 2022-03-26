using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentPropertyManagement.Models
{
  public class RenewRequest
  {
    public int Id { get; set; }

    public User Student { get; set; }

    public string StudentId { get; set; }

    public DateTime DateRequested { get; set; }

    public bool isFulfiled { get; set; }
  }
}

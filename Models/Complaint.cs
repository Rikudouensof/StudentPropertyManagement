using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentPropertyManagement.Models
{
  public class Complaint
  {
    public int Id { get; set; }

    public User User { get; set; }

    public string UserId { get; set; }

    public string Message { get; set; }

    public DateTime DatePosted { get; set; }
  }
}

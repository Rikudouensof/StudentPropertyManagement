using StudentPropertyManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentPropertyManagement.ViewModel
{
  public class StudentsListViewmodel
  {
    public IEnumerable<User> Users{ get; set; }
  }
}

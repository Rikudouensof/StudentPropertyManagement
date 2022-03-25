using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentPropertyManagement.Controllers
{
  public class DashbordController : Controller
  {
    public IActionResult Index()
    {
      return View();
    }
  }
}

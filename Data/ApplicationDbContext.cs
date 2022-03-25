using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StudentPropertyManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentPropertyManagement.Data
{
  public class ApplicationDbContext : IdentityDbContext<User>
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Gender> Genders { get; set; }

    public DbSet<AccomodationSpace> AccomodationSpaces { get; set; }
    public DbSet<Accomodation> Accomodations { get; set; }

    public DbSet<Buildings> Buildings { get; set; }

    public DbSet<Complaint> Complaints { get; set; }
  }
}

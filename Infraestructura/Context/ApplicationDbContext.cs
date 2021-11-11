using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Domain;
namespace Infraestructure.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
        //public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        
        public DbSet<Parameter> Parameters { get; set; }
        public DbSet<Process> Processes { get; set; }
        //public DbSet<Parameter> Parameters { get; set; }
    }
}

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksManagmentSystem.core.Models;

namespace TasksManagmentSystem.EF
{
    public class AppDbContext:IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options) {}

        public DbSet<Manager> Managers { get; set; }
       
       
    }
}

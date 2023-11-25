using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using TasksManagmentSystem.core.Dtos;
using TasksManagmentSystem.core.Models;

namespace TasksManagmentSystem.EF
{
    public class AppDbContext:IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options) {}

       

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            

            builder.Entity<User>().ToTable("User");
            builder.Entity<Manager>().ToTable("Managers", "AspNetUsers");    
            builder.Entity<Member>().ToTable("Members", "AspNetUsers");

            builder.Entity<Group>().HasMany(b => b.Projects).WithMany(b => b.Groups).UsingEntity<GroupProject>(
                j=>j.HasOne(b=>b.project).WithMany(b=>b.groupProjects).HasForeignKey(b=>b.PId).OnDelete(DeleteBehavior.Cascade),
                j=>j.HasOne(j=>j.group).WithMany(b=>b.groupProjects).HasForeignKey(b=>b.GId).OnDelete(DeleteBehavior.Cascade)
                );
            builder.Entity<Group>().HasMany(b => b.Members).WithMany(b => b.Groups).UsingEntity<GroupMember>(
                j => j.HasOne(b => b.member).WithMany(b => b.groupMembers).HasForeignKey(b => b.MId).OnDelete(DeleteBehavior.Cascade),
                j => j.HasOne(j => j.group).WithMany(b => b.groupMembers).HasForeignKey(b => b.GId).OnDelete(DeleteBehavior.Cascade)
                ); 


            builder.Entity<Manager>().HasMany(m => m.Tasks).WithOne(b => b.manager).HasForeignKey("ManagerId").OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Manager>().HasMany(m => m.Projects).WithOne(b => b.manager).HasForeignKey("ManagerId").OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Manager>().HasMany(m => m.Groups).WithOne(b => b.manager).HasForeignKey("ManagerId").OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Manager>().HasMany(m => m.Members).WithOne(b => b.manager).HasForeignKey("ManagerId").OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Task_>().HasOne(m => m.member).WithMany(b => b.Tasks).HasForeignKey("MemberId").OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Task_>().HasOne(m => m.project).WithMany(b => b.Tasks).HasForeignKey("ProjectId").OnDelete(DeleteBehavior.Cascade);
            
            //builder.Entity<Group>().Ignore(b => b.Projects);
           // builder.Entity<Project>().Ignore(b => b.Groups);

        }
        public  DbSet<Manager> Managers { get; set; }
        public  DbSet<Member> Members { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Task_> Tasks { get; set; }
        public DbSet<GroupProject> groupProjects { get; set; }
        public DbSet<GroupMember> groupMembers { get; set; }
       // public DbSet<MemberResDto> MemberResDtos { get; set; }



    }
}

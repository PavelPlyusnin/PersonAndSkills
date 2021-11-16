using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PersonAndSkills.Model;

namespace PersonAndSkills.Contexts
{
    public class Context: IdentityDbContext<IdentityUser>
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Skill> Skills { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(
                @"Server=(local)\\MSSQLLocalDB;Database=PersonSkill;Trusted_Connection=True;Data Source=localhost;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder
                .Entity<Person>()
                .HasMany(e => e.Skills)
                .WithOne()
                .OnDelete(DeleteBehavior.ClientCascade);

        }
    }
}

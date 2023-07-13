using ClubMembershipApplication.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMembershipApplication.Data
{
    public class ClubMembershipDbContext : DbContext 
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={AppDomain.CurrentDomain.BaseDirectory}ClubMembership.db");
            base.OnConfiguring(optionsBuilder);
        }

        // Run Add-Migration FirstCreate on the Package Manager Console
        // Hint: the 'Microsoft.EntityFrameworkCore.Sqlite' & 'Microsoft.EntityFrameworkCore.Tools' are needed
        public DbSet<User> User { get; set; }
    }
}

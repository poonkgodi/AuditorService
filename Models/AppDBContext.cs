using AuditorService.Controllers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditorService.Models
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions opts) : base(opts)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<AuditPortfolio> AuditPortfolios { get; set; }
        public DbSet<AuditRequest> AuditRequests { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
    }
}

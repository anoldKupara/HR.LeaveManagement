using HR.LeaveManagement.Domain;
using HR.LeaveManagement.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Persistence
{
    public class HrLeaveManagementDbContext : DbContext
    {
        public HrLeaveManagementDbContext(DbContextOptions<HrLeaveManagementDbContext> options )
            : base( options )
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(HrLeaveManagementDbContext).Assembly);
        }

        public override Task<int> SaveChangesAsync( CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseDomainEntities>())
            {
                entry.Entity.LastModifiedDate = DateTime.Now;

                if(entry.State == EntityState.Added)
                {
                    entry.Entity.DateCreated = DateTime.Now;
                }
            }

            return base.SaveChangesAsync( cancellationToken );
        }

        public DbSet<LeaveAllocation> LeaveAllocations { get; set; }
        public DbSet<LeaveRequest> LeaveRequests { get; set; }
        public DbSet<LeaveType> LeaveTypes { get; set; }
    }
}
